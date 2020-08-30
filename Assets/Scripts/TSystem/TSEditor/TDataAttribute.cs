using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public enum TDataFieldType
    {
        INT,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class TDataAttribute : Attribute
    {
        public string Name;
        public TDataFieldType FieldType;

        public TDataAttribute(string name)//, TDataFieldType fieldType)
        {
            Name = name;
        }
    }
}

