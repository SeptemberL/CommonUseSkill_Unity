using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    [Serializable]
    public class TriggerData : TData
    {
        [TDataAttribute("����������")]
        public string TriggerDesc;
        [TDataAttribute("��������")]
        public List<TEventType> TriggerEventType = new List<TEventType>();
        public List<TActionData> ActionDataList = new List<TActionData>();
        public TConditionData ConditionData;
        public TSelecterData SelecterData;
    }
}