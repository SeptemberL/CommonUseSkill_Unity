using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSystem
{
    /// <summary>
    /// TSystem 数据基类
    /// </summary>
    public class TData
    {
        public TData Parent;


        /// <summary>
        /// 复制函数
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

