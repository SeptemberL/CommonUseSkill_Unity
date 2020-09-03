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
        public string mName;
        public int mIndex = 0;
        public TDataFieldType FieldType;

        public TDataAttribute(string name)//, TDataFieldType fieldType)
        {
            mName = name;
        }

        public TDataAttribute(string name, int index)//, TDataFieldType fieldType)
        {
            mName = name;
            mIndex = index;
        }
    }
}

