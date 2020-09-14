using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    [Serializable]
    public class TriggerData : TData
    {
        [TDataAttribute("触发器描述")]
        public string TriggerDesc;
        [TDataAttribute("触发类型")]
        public List<TEventType> TriggerEventType = new List<TEventType>();
        public List<TActionData> ActionDataList = new List<TActionData>();
        public TConditionData ConditionData;
        public TSelecterData SelecterData;
    }
}