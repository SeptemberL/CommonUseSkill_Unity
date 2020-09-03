#if UNITY_EDITOR
    //#define DEBUG_LIST_POOL
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public interface ListPoolBase
{
    void DoSelfCheck(int nowSeconds);
}



public class ListPoolItem<T> : ListPoolBase
{
    public  int lastUsedSeconds;
    public  List<List<T>> pool;

#if DEBUG_LIST_POOL
    public static int usedSize = 0;
    public static int maxUsedSize = 0;
#endif

    public ListPoolItem(int initSize)
    {
        lastUsedSeconds = ThreadSafeElapsedTime.GetElapsedSecondsSinceStartUp();
        pool = new List<List<T>>(initSize);
    }

    public void DoSelfCheck(int nowSeconds)
    {
        if(pool.Count > 0)
        {
            int durationNotUse = nowSeconds - lastUsedSeconds;
            if (durationNotUse > 5 * 60) //x分钟
            {
                //LogHelper.LogEditorError("DoSelfCheck clear " + typeof(T).Name);
                pool.Clear();
            }
        }
    }

    public void Use(int add)
    {
        lastUsedSeconds = ThreadSafeElapsedTime.GetElapsedSecondsSinceStartUp();

#if DEBUG_LIST_POOL
        usedSize += add;

        if (add > 0 && usedSize > maxUsedSize)
        {
            if (maxUsedSize > 1)
            {
                string str = typeof(T).ToString();
                if(!str.Contains("System.WeakReference") && !str.Contains("UnityEngine.GameObject"))
                {
                    LogHelper.LogEditorError(VStringUtil.Concat("listPool increase size ", str, " ", usedSize.ToString(), " ", pool.Count.ToString()));
                }                
            }
            maxUsedSize = usedSize;
        }
#endif

        //if(typeof(T).FullName.Contains("PerkInfo"))
        //{
        //    LogHelper.LogEditorError(VStringUtil.Concat("listPool ", typeof(T).ToString(), " ", usedSize.ToString(), " ", pool.Count.ToString(), " ", add.ToString()));
        //}
    }
}

//负责监控listspool的使用情况
public static class ListPoolTracer
{
    private static int _timerMS;
    private static int _minTriggerTimeMS = 3000;
    private static List<object> poolItems = new List<object>();

    public static void Register(object poolItem)
    {
        poolItems.Add(poolItem);
    }

    public static void DoTracer(int deltaTimeMS)
    {
        _timerMS += deltaTimeMS;
        if(_timerMS < _minTriggerTimeMS)
        {
            return;
        }
        _timerMS = 0;

        int nowSeconds = ThreadSafeElapsedTime.GetElapsedSecondsSinceStartUp();
        for (int i = 0; i < poolItems.Count; ++i)
        {
            ListPoolBase poolItem = poolItems[i] as ListPoolBase;
            poolItem.DoSelfCheck(nowSeconds);
        }
    }
}


public static class ListPool<T>
{
    /** 池子的容量，为了防止池子无限制地扩大，超出池子容量的list不再回收 */
    public static int maxPoolSize = 4;   


    
    /** Internal pool */
    static ListPoolItem<T> poolItem;


    /** Static constructor */
    static ListPool()
    {
        poolItem = new ListPoolItem<T>(maxPoolSize);
        ListPoolTracer.Register(poolItem);
    }

    public static List<T> Claim()
    {
        lock(poolItem)
        {
            poolItem.Use(1);

            List<List<T>> pool = poolItem.pool;

            int curPoolSize = pool.Count;
            if (curPoolSize > 0)
            {
                List<T> objList = pool[curPoolSize - 1];
                pool.RemoveAt(curPoolSize - 1);
                return objList;
            }
            else
            {
                return new List<T>();
            }
        }
    }

    /// <summary>
    /// ref后,objectList会被设置为null
    /// </summary>
    /// <param name="objList"></param>
    public static void Release(ref List<T> objList)
    {
        if (objList == null) return;

        lock (poolItem)
        {
            poolItem.Use(-1);
            List<List<T>> pool = poolItem.pool;
            List<T> objList2 = objList;
            objList = null;


//#if UNITY_EDITOR
            if (pool.Contains(objList2))
            {
                Debug.LogError("ListPool Release list already in pool " + objList2.GetType().ToString());
                return;
            }
//#endif
            objList2.Clear();

            if (objList2.Capacity >= 4096)
            {
                objList2.TrimExcess();
                Debug.LogError("harmless recycle list capacity " + objList2.Capacity);
            }


            int curPoolSize = pool.Count;
            if (curPoolSize >= maxPoolSize)
            {
                //去掉capacity最大的list
                int removeIndex = -1;
                int maxCapacity = objList2.Capacity;
                for (int i = 0; i < curPoolSize; ++i)
                {
                    List<T> curList = pool[i];
                    if (curList.Capacity > maxCapacity)
                    {
                        removeIndex = i;
                        maxCapacity = curList.Capacity;
                    }
                }

                if (removeIndex >= 0)
                {
                    pool[removeIndex] = objList2;
                }
                return;
            }
            pool.Add(objList2);
        }
    }
}
