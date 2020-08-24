using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public class TriggerData : TData
    {
        public List<TEventType> TriggerEventType = new List<TEventType>();
        public List<TActionData> ActionDataList = new List<TActionData>();
        public TConditionData ConditionData;
        public TSelecterData SelecterData;

        /// <summary>
        /// �ڵ�����
        /// </summary>
        public string Desc;
    }
}