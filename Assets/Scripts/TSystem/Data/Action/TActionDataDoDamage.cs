using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public class TActionDataDoDamage : TActionData
    {
        [TDataAttribute("这是啥")]
        public int DefaultIndex;

        [TDataAttribute("啥啥啥")]
        public string DefaultStr;

        [TDataAttribute("啥啥啥ds")]
        public TActionType mType;

       public override TActionType GetDataType()
       {
           return TActionType.TACTION_DO_DAMAGE;
       }
    }
}

