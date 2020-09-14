using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public class ContainerData : TData
    {
        [TDataAttribute("�������б�", true)]
        public List<TriggerData> Triggers = new List<TriggerData>();
    }
}
