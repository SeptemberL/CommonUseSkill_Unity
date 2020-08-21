
///////////////////////////////////////////////////////////////////////////////
//
//                  技能系统模板Json数据序列化类
//                                              By:sunjianqiang
//
///////////////////////////////////////////////////////////////////////////////using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace TSystem
{
    public class TriggerJsonSerialization
    {
        public static string Save(TData skillData)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            TriggerJsonSerialization.SerializeFields(skillData, ref dictionary);

            string jsonStr = MiniJSON.Json.Serialize(dictionary);
            //TriggerJsonDeserialization.Load(jsonStr);
            return jsonStr;
        }

/*
        public static Dictionary<string, object> SerializeEffectContainer(EffectContainerData trigger)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            SerializeFields(trigger, ref dict);

            return dict;
        }

        */
        public static Dictionary<string, object> SerializeBaseData(TData baseData)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Type", baseData.GetType());
            SerializeFields(baseData, ref dict);
            return dict;
        }

        private static void SerializeFields(object obj, ref Dictionary<string, object> dict)
        {
            if (obj == null)
            {
                Debug.LogError("SerializeFields obj == null");
                return;
            }
            
            FieldInfo[] allFields = BaseDataUtility.GetAllFields(obj.GetType());
            for (int index1 = 0; index1 < allFields.Length; ++index1)
            {
                if (BaseDataUtility.HasAttribute(allFields[index1], typeof(NonSerializedAttribute))     //NonSerializedAttribute标志
                    || allFields[index1].IsPrivate                                                      //私有变量
                    || allFields[index1].GetValue(obj) == null)                                         //空的
                    continue;

                string key1 = (allFields[index1].FieldType.Name + allFields[index1].Name).ToString();

                if(allFields[index1].FieldType.Equals(typeof (float)))
                {
                    Debug.Log("Type: " + obj);
                }
                if (allFields[index1].FieldType.IsPrimitive
                    || allFields[index1].FieldType.IsEnum
                    || (allFields[index1].FieldType.Equals(typeof(string))
                    || allFields[index1].FieldType.Equals(typeof(Vector2)))
                    || (allFields[index1].FieldType.Equals(typeof(Vector3))
                    || allFields[index1].FieldType.Equals(typeof(Vector4))
                    || (allFields[index1].FieldType.Equals(typeof(Quaternion))
                    || allFields[index1].FieldType.Equals(typeof(Matrix4x4))))
                    || (allFields[index1].FieldType.Equals(typeof(Color))
                    || allFields[index1].FieldType.Equals(typeof(Rect))))
                {
                    dict.Add(key1, allFields[index1].GetValue(obj));
                }
                else if (typeof(TData).IsAssignableFrom(allFields[index1].FieldType))
                {
                    TData task = allFields[index1].GetValue(obj) as TData;
                    Dictionary<string, object> command = new Dictionary<string, object>();
                    command = SerializeBaseData(task);
                    dict.Add(key1, command);
                }
                else if (typeof(IList).IsAssignableFrom(allFields[index1].FieldType))
                {
                    IList list = allFields[index1].GetValue(obj) as IList;
                    if (list != null)
                    {
                        List<object> objectList1 = new List<object>();
                        for (int index2 = 0; index2 < list.Count; ++index2)
                        {
                            if (list[index2] == null)
                            {
                                objectList1.Add((object)null);
                            }
                            else
                            {
                                Type type = list[index2].GetType();
                                if (list[index2] == null)
                                    continue;
                                if (list[index2] is TData)
                                {
                                    Dictionary<string, object> command = new Dictionary<string, object>();
                                    command = SerializeBaseData((TData)list[index2]);
                                    objectList1.Add((object)command);
                                }
                                else if (type.IsPrimitive || type.IsEnum || (type.Equals(typeof(string)) || type.Equals(typeof(Vector2))) || (type.Equals(typeof(Vector3)) || type.Equals(typeof(Vector4)) || (type.Equals(typeof(Quaternion)) || type.Equals(typeof(Matrix4x4)))) || (type.Equals(typeof(Color)) || type.Equals(typeof(Rect))))
                                {
                                    objectList1.Add(list[index2]);
                                }
                                else 
                                {
                                    Dictionary<string, object> data = new Dictionary<string, object>();
                                    SerializeFields(list[index2], ref data);
                                    objectList1.Add((object)data);
                                }
                            }
                        }
                        if (objectList1 != null)
                            dict.Add(key1, (object)objectList1);
                    }
                }
                else
                {
                    Dictionary<string, object> dict1 = new Dictionary<string, object>();
                    TriggerJsonSerialization.SerializeFields(allFields[index1].GetValue(obj), ref dict1);
                    dict.Add(key1, (object)dict1);
                }
            }
        }
    }
}
