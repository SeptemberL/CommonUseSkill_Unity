using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TDataAttribute : Attribute
    {
        public string Name;


    }
}

