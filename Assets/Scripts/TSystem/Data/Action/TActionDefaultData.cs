using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    public class TActionDefaultData : TActionData
    {
       public override TActionType GetDataType()
       {
           return TActionType.TACTION_DEFAULT;
       }
    }
}

