﻿using NodeEditorFramework.Utilities;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace NodeEditorFramework
{
    public abstract partial class Node : ScriptableObject
    {
        protected const int DefaultWidth = 300;
        protected const int DefaultHeight = 160;
        public const int HeightOffset = 20;

        protected internal virtual void OnRemoveConnection(ConnectionPort port, ConnectionPort connection) { }

        protected virtual void FlushData()
        {

        }

    }
}
