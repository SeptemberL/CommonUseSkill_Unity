using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using NodeEditorFramework.Utilities;
using System;

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
        public static void DrawTDataVars(TData data)
        {
            TDataDeclaration[] decs =  GetPortDeclarations(data.GetType().Name);
            if(decs != null && decs.Length > 0)
            {
                List<TDataDeclaration> decsList = new ListPool<TDataDeclaration>.Get();
                decsList.AddRange(decs);
                decsList.Sort((a,b)=>{ return a.tDataAttributeInfo.mIndex - b.tDataAttributeInfo.mIndex;});
                for(int i = 0; i < decsList.Count; i++)
                {
                    TDataDeclaration dec = decs[i];
                    DrawDataDec(dec, data);       
                }
                ListPool<TDataDeclaration>.Release(decsList);
            }
            
        }

        public static void DrawDataDec(TDataDeclaration dec, TData data)
        {
            ///绘制int类型
            if(dec.tDataField.FieldType.Equals(typeof(int)))
            {
                int val = (int)dec.tDataField.GetValue(data);
                val = RTEditorGUI.IntField(dec.tDataAttributeInfo.mName, val);
                dec.tDataField.SetValue(data, val);
            }
            ///绘制string类型
            else if(dec.tDataField.FieldType.Equals(typeof(string)))
            {
                string val = (string)dec.tDataField.GetValue(data);
                val = RTEditorGUI.TextField(new GUIContent(dec.tDataAttributeInfo.mName), val);
                dec.tDataField.SetValue(data, val);
            }      
            else if(dec.tDataField.FieldType.BaseType.Equals(typeof(System.Enum)))
            {
                System.Enum val = (System.Enum)dec.tDataField.GetValue(data);
                val = RTEditorGUI.EnumPopup(new GUIContent(dec.tDataAttributeInfo.mName), val);
                dec.tDataField.SetValue(data, val);
            }  
        }

    }
}