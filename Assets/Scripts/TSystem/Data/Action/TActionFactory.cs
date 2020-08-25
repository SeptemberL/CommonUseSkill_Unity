using UnityEngine;
using System.Collections.Generic;
using System;
using NodeEditorFramework.Utilities;

namespace TSystem
{
    public class TActionFactory
    {
        public static Dictionary<TActionType, Type> TActionDataTypes;
        //public static Dictionary<CommandType, Type> CommandTypes;

        /// <summary>
        /// 获取所有CommandData子类型
        /// </summary>
        public static void CollectTActionDataTypes()
        {
            TActionDataTypes = new Dictionary<TActionType, Type>();

            foreach (Type type in ReflectionUtility.getSubTypes(typeof(TActionData)))
            {
                TActionData taction = (TActionData)Activator.CreateInstance(type);
                if (taction == null)
                    throw new UnityException("Error with TActionData " + type.FullName);
                if (TActionDataTypes.ContainsKey(taction.GetDataType()))
                    throw new Exception("Duplicate TActionData declaration " + taction.GetDataType() + "!");

                TActionDataTypes.Add(taction.GetDataType(), type);
            }
        }

        /// <summary>
        /// 创建CommandData
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TActionData CreateTActionData(TActionType type)
        {
            if (TActionDataTypes == null || TActionDataTypes.Count == 0)
            {
                CollectTActionDataTypes();
            }
            if(TActionDataTypes.ContainsKey(type))
            {
                TActionData taction = (TActionData)Activator.CreateInstance(TActionDataTypes[type]);
                return taction;
            }
            return null;
        }

        /*
        /// <summary>
        /// 获取所有CommandData子类型
        /// </summary>
        public static void CollectCommandTypes()
        {
            CommandTypes = new Dictionary<CommandType, Type>();

            foreach (Type type in ReflectionUtility.getSubTypes(typeof(Command)))
            {
                Command command = (Command)Activator.CreateInstance(type);
                if (command == null)
                    throw new UnityException("Error with Command " + type.FullName);
                if (CommandTypes.ContainsKey(command.GetDataType()))
                    throw new Exception("Duplicate Command declaration " + command.GetDataType() + "!");

                CommandTypes.Add(command.GetDataType(), type);
            }
        }

        /// <summary>
        /// 创建CommandData
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Command CreateCommand(CommandType type)
        {
            if (CommandTypes == null || CommandTypes.Count == 0)
            {
                CollectCommandTypes();
            }
            if (CommandTypes.ContainsKey(type))
            {
                Command command = (Command)Activator.CreateInstance(CommandTypes[type]);
                return command;
            }
            return null;
        }
        */
    }
}