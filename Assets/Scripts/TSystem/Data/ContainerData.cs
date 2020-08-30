using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public class ContainerData : TData
    {
        [TDataAttribute("Trigger List")]
        public List<TriggerData> Triggers = new List<TriggerData>();
    }
}
