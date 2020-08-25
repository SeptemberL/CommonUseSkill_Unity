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
                variableDeclarations.Add(type.ToString(), tattrs.ToArray());
            }
        }

    }
}