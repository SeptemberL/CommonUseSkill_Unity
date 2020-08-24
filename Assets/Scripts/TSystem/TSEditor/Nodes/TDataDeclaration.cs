using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace TSystem
{
    public class TDataDeclaration
    {
        public FieldInfo tDataField;
        public TDataAttribute tDataAttributeInfo;

        public TDataDeclaration(FieldInfo field, TDataAttribute attr)
        {
            tDataField = field;
            tDataAttributeInfo = attr;
        }
    }
}