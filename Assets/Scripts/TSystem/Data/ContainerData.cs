using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public class ContainerData : TData
    {
        [TDataAttribute("´¥·¢Æ÷ÁÐ±í", true)]
        public List<TriggerData> Triggers = new List<TriggerData>();
    }
}
