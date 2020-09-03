using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public abstract class TActionData : TData
    {
        [TDataAttribute("命令描述", 999)]
        public string TActionDesc;

       public abstract TActionType GetDataType();
    }
}

