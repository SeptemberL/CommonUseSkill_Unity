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
        public int Index = 0;
        public TDataFieldType FieldType;
        public bool NotDraw = false;

        public TDataAttribute(string name)//, TDataFieldType fieldType)
        {
            Name = name;
        }

        public TDataAttribute(string name, int index)//, TDataFieldType fieldType)
        {
            Name = name;
            Index = index;
        }

        public TDataAttribute(string name, bool notDraw)//, TDataFieldType fieldType)
        {
            Name = name;
            NotDraw = notDraw;
        }
    }
}

