using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    [Serializable]
    public class SkillData : ContainerData
    {
        [TDataAttribute("������")]
        public string Name;
    }
}