///////////////////////////////////////////////////////////////////////////////
//
//                  技能系统模板Json数据解析类
//                                              By:sunjianqiang
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace TSystem
{
    public class TriggerJsonDeserialization
    {
        public static bool updatedSerialization = true;
        /*
        /// <summary>
        /// 读取技能数据
        /// </summary>
        /// <param name="skillData"></param>
        public static TData LoadSkillDatabase(string skillData)
        {
            SkillTempleteData st = new SkillTempleteData();
            return LoadDatabase(st, skillData);
        }

        /// <summary>
        /// 读取Trigger数据
        /// </summary>
        /// <param name="skillData"></param>
        public static TData LoadTriggerDatabase(string skillData)
        {
            TriggerEntityData data = new TriggerEntityData();
            return LoadDatabase(data, skillData);
        }

        /// <summary>
        /// 读取Effect数据
        /// </summary>
        /// <param name="skillData"></param>
        public static TData LoadEffectDatabase(string skillData)
        {
            EffectContainerData data = new EffectContainerData();
            return LoadDatabase(data, skillData);
        }
*/
        static TData LoadDatabase(TData baseData, string skilldata)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary = (Dictionary<string, object>)MiniJSON.Json.Deserialize(skilldata);
            if (dictionary == null)
            {
                Debug.LogError("Failed to deserialize");
                return null;
            }
            else
            {
                DeserializeObject(null, baseData, dictionary);
                baseData.IsChange = false;
            }
            return baseData;
        }


        private static void DeserializeObject(TData baseData, object obj, Dictionary<string, object> dict)
        {
            if (dict == null)
                return;
            FieldInfo[] allFields = BaseDataUtility.GetAllFields(obj.GetType());
            for (int index1 = 0; index1 < allFields.Length; ++index1)
            {
                string key = !TriggerJsonDeserialization.updatedSerialization ? (allFields[index1].FieldType.Name.GetHashCode() + allFields[index1].Name.GetHashCode()).ToString() : allFields[index1].FieldType.Name + allFields[index1].Name;
                object obj1;
                if (dict.TryGetValue(key, out obj1))
                {
                    if (typeof(IList).IsAssignableFrom(allFields[index1].FieldType))
                    {
                        IList list = obj1 as IList;
                        if (list != null)
                        {
                            Type type1;
                            if (allFields[index1].FieldType.IsArray)
                            {
                                type1 = allFields[index1].FieldType.GetElementType();
                            }
                            else
                            {
                                Type type2 = allFields[index1].FieldType;
                                while (!type2.IsGenericType)
                                    type2 = type2.BaseType;
                                type1 = type2.GetGenericArguments()[0];
                            }
                             if (type1.Equals(typeof(TData)) || type1.IsSubclassOf(typeof(TData)))
                             {

                             }
                            if (allFields[index1].FieldType.IsArray)
                            {
                                Array instance = Array.CreateInstance(type1, list.Count);
                                for (int index2 = 0; index2 < list.Count; ++index2)
                                {
                                    if (list[index2] == null)
                                        instance.SetValue((object)null, index2);
                                    else
                                        instance.SetValue(ValueToObject(baseData, type1, list[index2]), index2);
                                }
                                allFields[index1].SetValue(obj, (object)instance);
                            }
                            else
                            {
                                IList instance;
                                if (allFields[index1].FieldType.IsGenericType)
                                    instance = BaseDataUtility.CreateInstance(typeof(List<>).MakeGenericType(type1)) as IList;
                                else
                                    instance = BaseDataUtility.CreateInstance(allFields[index1].FieldType) as IList;
                                for (int index2 = 0; index2 < list.Count; ++index2)
                                {
                                    if (list[index2] == null)
                                        instance.Add((object)null);
                                    else
                                        instance.Add(ValueToObject(baseData, type1, list[index2]));
                                }
                                allFields[index1].SetValue(obj, (object)instance);
                            }//allFields[index1].FieldType.IsArray)
                        }//list != null
                    }//typeof(IList).IsAssignableFrom(allFields[index1].FieldType))
                    else
                    {
                        Type fieldType = allFields[index1].FieldType;
                        if (fieldType.Equals(typeof(TData)) || fieldType.IsSubclassOf(typeof(TData)))
                        {
                            //if (BaseDataUtility.HasAttribute(allFields[index1], typeof(InspectBaseDataAttribute)))
                            {
                                Dictionary<string, object> dict1 = obj1 as Dictionary<string, object>;
                                Type typeWithinAssembly = BaseDataUtility.GetTypeWithinAssembly(dict1["Type"] as string);
                                if (typeWithinAssembly != null)
                                {
                                    TData instance = BaseDataUtility.CreateInstance(typeWithinAssembly) as TData;
                                    DeserializeObject(instance, (object)instance, dict1);
                                    allFields[index1].SetValue(obj, (object)instance);
                                }
                            }

                        }
                        else
                            allFields[index1].SetValue(obj, ValueToObject(baseData, fieldType, obj1));
                    }
                }
            }
        }


        private static object ValueToObject(TData baseData, Type type, object obj)
        {
            if (typeof(TActionData).IsAssignableFrom(type))
            {
                Dictionary<string, object> dict1 = obj as Dictionary<string, object>;
                Type typeWithinAssembly = BaseDataUtility.GetTypeWithinAssembly(dict1["Type"] as string);
                if (typeWithinAssembly != null)
                {
                    TData instance = BaseDataUtility.CreateInstance(typeWithinAssembly) as TData;
                    DeserializeObject(instance, (object)instance, dict1);
                    return (object)instance;
                }
            }
            if (!type.IsPrimitive)
            {
                if (!type.Equals(typeof(string)))
                {
                    if (type.IsSubclassOf(typeof(Enum)))
                    {
                        try
                        {
                            return Enum.Parse(type, (string)obj);
                        }
                        catch (Exception)
                        {
                            return (object)null;
                        }
                    }
                    else
                    {
                        if (type.Equals(typeof(Vector2)))
                        {
                            Vector2 result = new Vector2();
                            NormalFunctions.ParseVector2(ref result, (string)obj);
                            return (object)result;
                        }
                        if (type.Equals(typeof(Vector3)))
                        {
                            Vector3 result = new Vector3();
                            NormalFunctions.ParseVector3(ref result, (string)obj);
                            return (object)result;
                        }
                        if (type.Equals(typeof(Vector4)))
                        {
                            Vector4 result = new Vector4();
                            NormalFunctions.ParseVector4(ref result, (string)obj);
                            return (object)result;
                        }
                        if (type.Equals(typeof(Color)))
                        {
                            Color result = NormalFunctions.ParseColorRGBA((string)obj);
                            return (object)result;
                        }

                        object instance = BaseDataUtility.CreateInstance(type);
                        DeserializeObject(baseData, instance, obj as Dictionary<string, object>);
                        return instance;

                    }
                }
            }
            try
            {
                return Convert.ChangeType(obj, type);
            }
            catch (Exception)
            {
                return (object)null;
            }
        }
    }
}
