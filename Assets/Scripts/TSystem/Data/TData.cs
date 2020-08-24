using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    /// <summary>
    /// TSystem ���ݻ���
    /// </summary>
    public class TData
    {
        public TData Parent;

        ///是否有更改
        public bool IsChange;


        /// <summary>
        /// ���ƺ���
        /// </summary>
        /// <returns></returns>
        public virtual TData Clone()
        {
            TData data = new TData();
            CopyTo(data);
            return data;
        }

        protected virtual void CopyTo(TData destinationData)
        {

        }

#if UNITY_EDITOR

        

        /// <summary>
        /// 通过标签收集需要显示在UI上的变量
        /// </summary>
        public void FetchVarDeclarations()
        {
            variableDeclarations = new Dictionary<string, TDataDeclaration[]>();
            foreach (NodeTypeData nodeData in NodeTypes.getNodeDefinitions())
            {
                Type nodeType = nodeData.type;
                List<ConnectionPortDeclaration> declarations = new List<ConnectionPortDeclaration>();
                // Get all declared port fields
                FieldInfo[] declaredPorts = ReflectionUtility.getFieldsOfType(nodeType, typeof(ConnectionPort));
                foreach (FieldInfo portField in declaredPorts)
                { // Get info about that port declaration using the attribute
                    object[] declAttrs = portField.GetCustomAttributes(typeof(ConnectionPortAttribute), true);
                    if (declAttrs.Length < 1)
                        continue;
                    //ConnectionPortAttribute declarationAttr = (ConnectionPortAttribute)declAttrs[0];
                    //if (declarationAttr.MatchFieldType(portField.FieldType))
                        declarations.Add(new TDataDeclaration(portField, declarationAttr));
                    //else
                    //    Debug.LogError("Mismatched " + declarationAttr.GetType().Name + " for " + portField.FieldType.Name + " '" + declarationAttr.Name + "' on " + nodeData.type.Name + "!");
                }
                nodePortDeclarations.Add(nodeData.typeID, declarations.ToArray());
            }
        }

        public virtual string GetName_Editor()
        {
            return "";
        }


        public virtual void SetValueCountEditor(int newValue)
        {

        }
#endif
    }


}

