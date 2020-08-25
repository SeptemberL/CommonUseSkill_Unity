using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    /// <summary>
    /// TSystem ���ݻ���
    /// </summary>
    public class TData
    {
        public TData Parent;

        ///是否有更改
        public bool IsChange;


        /// <summary>
        /// ���ƺ���
        /// </summary>
        /// <returns></returns>
        public virtual TData Clone()
        {
            TData data = new TData();
            CopyTo(data);
            return data;
        }

        protected virtual void CopyTo(TData destinationData)
        {

        }

#if UNITY_EDITOR

       
        public virtual string GetName_Editor()
        {
            return "";
        }


        public virtual void SetValueCountEditor(int newValue)
        {

        }
#endif
    }


}

