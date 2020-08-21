using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TSystem
{
    public class BaseDataUtility
    {
        [NonSerialized]
        private static Dictionary<string, Type> typeLookup = new Dictionary<string, Type>();
        private static List<string> loadedAssemblies = (List<string>)null;
        private static Dictionary<Type, FieldInfo[]> allFieldsLookup = new Dictionary<Type, FieldInfo[]>();
        [NonSerialized]
        private static Dictionary<Type, Dictionary<FieldInfo, bool>> attributeFieldCache = new Dictionary<Type, Dictionary<FieldInfo, bool>>();

        public static object CreateInstance(Type t)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                t = Nullable.GetUnderlyingType(t);
            return Activator.CreateInstance(t, true);
        }

        public static FieldInfo[] GetAllFields(Type t)
        {
            FieldInfo[] fieldInfoArray = (FieldInfo[])null;
            if (!BaseDataUtility.allFieldsLookup.TryGetValue(t, out fieldInfoArray))
            {
                List<FieldInfo> fieldList = new List<FieldInfo>();
                fieldList.Clear();
                BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                BaseDataUtility.GetFields(t, ref fieldList, (int)bindingFlags);
                fieldInfoArray = fieldList.ToArray();
                BaseDataUtility.allFieldsLookup.Add(t, fieldInfoArray);
            }
            return fieldInfoArray;
        }

        private static void GetFields(Type t, ref List<FieldInfo> fieldList, int flags)
        {
            if (t == null) // || t.Equals(typeof(ParentTask)) || (t.Equals(typeof(Task)) || t.Equals(typeof(SharedVariable))))
                return;
            foreach (FieldInfo field in t.GetFields((BindingFlags)flags))
                fieldList.Add(field);
            BaseDataUtility.GetFields(t.BaseType, ref fieldList, flags);
        }

        public static Type GetTypeWithinAssembly(string typeName)
        {
            Type type1;
            if (typeLookup.TryGetValue(typeName, out type1))
                return type1;
            Type type2 = Type.GetType(typeName);
            if (type2 == null)
            {
                if (loadedAssemblies == null)
                {
                    loadedAssemblies = new List<string>();
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                        loadedAssemblies.Add(assembly.FullName);
                }
                for (int index = 0; index < loadedAssemblies.Count; ++index)
                {
                    type2 = Type.GetType(typeName + "," + loadedAssemblies[index]);
                    if (type2 != null)
                        break;
                }
            }
            if (type2 != null)
                typeLookup.Add(typeName, type2);
            return type2;
        }

        public static bool HasAttribute(FieldInfo field, Type attributeType)
        {
            Dictionary<FieldInfo, bool> dictionary = (Dictionary<FieldInfo, bool>)null;
            if (attributeFieldCache.ContainsKey(attributeType))
                dictionary = attributeFieldCache[attributeType];
            if (dictionary == null)
                dictionary = new Dictionary<FieldInfo, bool>();
            if (dictionary.ContainsKey(field))
                return dictionary[field];
            bool flag = field.GetCustomAttributes(attributeType, false).Length > 0;
            dictionary.Add(field, flag);
            if (!attributeFieldCache.ContainsKey(attributeType))
                attributeFieldCache.Add(attributeType, dictionary);
            return flag;
        }
    }
}
