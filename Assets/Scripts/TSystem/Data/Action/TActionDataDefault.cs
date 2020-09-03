using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public class TActionDataDefault : TActionData
    {
        [TDataAttribute("这是啥")]
        public int DefaultIndex;

       public override TActionType GetDataType()
       {
           return TActionType.TACTION_DEFAULT;
       }
    }
}

