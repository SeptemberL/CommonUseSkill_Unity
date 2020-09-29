using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using NodeEditorFramework.Utilities;
using System;
using System.Collections;
using NodeEditorFramework;

namespace TSystem
{
    public static class TDataVarManager 
    {
        private static Dictionary<string, TDataDeclaration[]> variableDeclarations;

        /// <summary>
        /// Fetches every node connection declaration for each node type for later use
        /// </summary>
        public static void FetchNodeConnectionDeclarations()
        {
            variableDeclarations = new Dictionary<string, TDataDeclaration[]>();
            foreach(Type type in ReflectionUtility.getSubTypes(typeof(TData)))
            {
                List<TDataDeclaration> tattrs = new List<TDataDeclaration>();
                // Get all declared port fields
                FieldInfo[] tdataAttr = ReflectionUtility.getSerializedFields(type);
                foreach (FieldInfo tattr in tdataAttr)
                { // Get info about that port declaration using the attribute
                    object[] declAttrs = tattr.GetCustomAttributes(typeof(TDataAttribute), true);
                    if (declAttrs.Length < 1)
                        continue;
                    TDataAttribute declarationAttr = (TDataAttribute)declAttrs[0];
                    //if (declarationAttr.MatchFieldType(tattr.FieldType))
                        tattrs.Add(new TDataDeclaration(tattr, declarationAttr));
                    //else
                    //    Debug.LogError("Mismatched " + declarationAttr.GetType().Name + " for " + tattr.FieldType.Name + " '" + declarationAttr.Name + "' on " + nodeData.type.Name + "!");
                }
                variableDeclarations.Add(type.Name, tattrs.ToArray());
            }
        }

        /// <summary>
		/// Returns the variableDeclarations for the given node type
		/// </summary>
		public static TDataDeclaration[] GetPortDeclarations(string tDataTypeID)
        {
            TDataDeclaration[] decls;
            if (variableDeclarations.TryGetValue(tDataTypeID, out decls))
                return decls;
            else
                throw new ArgumentException("Could not find node port declarations for node type '" + tDataTypeID + "'!");
        }

        //绘制TData内需要绘制的变量
        public static int DrawTDataVars(TData data, ref bool changed)
        {
            int width = 0;
            TDataDeclaration[] decs =  GetPortDeclarations(data.GetType().Name);
            if(decs != null && decs.Length > 0)
            {
                List<TDataDeclaration> decsList = ListPool<TDataDeclaration>.Claim();
                decsList.AddRange(decs);
                decsList.Sort((a,b)=>{ return b.tDataAttributeInfo.Index - a.tDataAttributeInfo.Index;});
                for(int i = 0; i < decsList.Count; i++)
                {
                    TDataDeclaration dec = decsList[i];
                    if (dec.tDataAttributeInfo.NotDraw)
                        continue;
                    width += DrawDataDec(dec, data, ref changed);       
                }
                ListPool<TDataDeclaration>.Release(ref decsList);
            }
            return width;
        }

        public static int DrawDataDec(TDataDeclaration dec, TData data, ref bool changed)
        {
            int result = 0;
            if(dec.tDataField.FieldType.ToString().Contains("System.Collections.Generic.List"))
            {
                IList var = (IList)dec.tDataField.GetValue(data);
                Type[] types = dec.tDataField.FieldType.GetGenericArguments();
                if(types.Length > 0)
                {
                    int num = var.Count;
                    string name = StringUtil.Concat(dec.tDataAttributeInfo.Name, ":", var.Count.ToString());
                    if (EditorUtil.DrawHeader(name))
                    {
                        num = RTEditorGUI.IntField(new GUIContent("数量:"), num);
                        if (var.Count > num)
                        {
                            for (int i = var.Count - 1; i > num - 1; i--)
                            {
                                var.RemoveAt(i);
                            }
                        }
                        else
                        {
                            for (int i = var.Count; i < num; i++)
                            {
                                var.Add(Activator.CreateInstance(types[0]));
                            }
                        }
                        for (int i = 0; i < var.Count; i++)
                        {
                            var[i] = DrawVar(var[i], types[0], i.ToString());
                        }
                        result += Node.HeightOffset + var.Count * Node.HeightOffset;
                    }
                }
            }
            else
            {
                result += Node.HeightOffset;
                DrawByType(dec.tDataField, data, dec.tDataAttributeInfo.Name);
            }
            if (GUI.changed)
            {
                changed = true;
            }
            return result;
        }

        static void DrawByType(FieldInfo info, TData data, string name)
        {
            object var = info.GetValue(data);
            var = DrawVar(var, info.FieldType, name);
            info.SetValue(data, var);
        }

        static object DrawVar(object var, Type type, string name)
        {
            if(type == typeof(int))
            {
                var = RTEditorGUI.IntField(new GUIContent(name), (int)var);
            }
            else if (type.BaseType.Equals(typeof(System.Enum)))
            {
                var = RTEditorGUI.EnumPopup(new GUIContent(name), (System.Enum)var);
            }
            ///绘制string类型
            else if (type.Equals(typeof(string)))
            {
                var = RTEditorGUI.TextField(new GUIContent(name), (string)var);
            }
            //绘制bool类型
            else if (type.Equals(typeof(bool)))
            {
                var = RTEditorGUI.Toggle(new GUIContent(name), (bool)var);
            }
            
            return var;
        }

    }
}