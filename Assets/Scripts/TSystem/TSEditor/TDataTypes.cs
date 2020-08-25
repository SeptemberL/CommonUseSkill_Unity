using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using NodeEditorFramework.Utilities;

namespace TSystem
{
    public static class TDataTypes
    {
        private static Dictionary<string, TDataTypeData> nodes;

        /// <summary>
        /// 收集所有TData子类的fieldInfo
        /// </summary>
        public static void FetchNodeTypes()
        {
            nodes = new Dictionary<string, TDataTypeData>();
            foreach (Type type in ReflectionUtility.getSubTypes(typeof(TData)))
            {
//                 object[] nodeAttributes = type.GetCustomAttributes(typeof(NodeAttribute), false);
//                 NodeAttribute attr = nodeAttributes[0] as NodeAttribute;
//                 if (attr == null || !attr.hide)
//                 { // Only regard if it is not marked as hidden
//                   // Fetch node information
//                     string ID, Title = "None";
//                     FieldInfo IDField = type.GetField("ID");
//                     if (IDField == null || attr == null)
//                     { // Cannot read ID from const field or need to read Title because of missing attribute -> Create sample to read from properties
//                         Node sample = (Node)ScriptableObject.CreateInstance(type);
//                         ID = sample.GetID;
//                         Title = sample.Title;
//                         UnityEngine.Object.DestroyImmediate(sample);
//                     }
//                     else // Can read ID directly from const field
//                         ID = (string)IDField.GetValue(null);
//                     // Create Data from information
//                     NodeTypeData data = attr == null ?  // Switch between explicit information by the attribute or node information
//                         new NodeTypeData(ID, Title, type, new Type[0]) :
//                         new NodeTypeData(ID, attr.contextText, type, attr.limitToCanvasTypes);
//                     nodes.Add(ID, data);
//                 }
            }
        }
    }

    public struct TDataTypeData
    {
        public string typeID;
        public string adress;
        public Type type;
        public Type[] limitToCanvasTypes;

        public TDataTypeData(string ID, string name, Type nodeType, Type[] limitedCanvasTypes)
        {
            typeID = ID;
            adress = name;
            type = nodeType;
            limitToCanvasTypes = limitedCanvasTypes;
        }
    }

}