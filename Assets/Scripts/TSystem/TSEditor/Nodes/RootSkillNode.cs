using UnityEngine;
using NodeEditorFramework.Utilities;
using System.Reflection;
using System.CodeDom;
using System;
using TSystem;

namespace NodeEditorFramework.Standard
{
    [Node(false, "Skill/Skill Root")]
    public class RootSkillNode : Node
    {
        public const string ID = "rootSkillNode";
        public override string GetID { get { return ID; } }

        public override string Title { get { return "Skill Root Node"; } }
        public override Vector2 DefaultSize { get { return new Vector2(150, 100); } }

        [ConnectionKnob("Triggers", Direction.Out, TriggerNode.Name)]
        public ConnectionKnob triggers;

        public SkillData SkillData;

        public override void NodeGUI()
        {
            name = RTEditorGUI.TextField(name);

            //SkillData.SkillName = RTEditorGUI.TextField(new GUIContent("技能名", "技能名"), SkillData.SkillName);
            //SkillData.SkillName = RTEditorGUI.TextField(new GUIContent("技能名", "技能名"), SkillData.SkillName);

            foreach (ConnectionKnob knob in connectionKnobs)
                knob.DisplayLayout();

            DrawBaseDataValue(typeof(SkillData), SkillData);
        }

        #region Self Function
        public void DrawBaseDataValue(System.Type type, TData data)
        {
            
            FieldInfo[] fields = ReflectionUtility.getSerializedFields(type);
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo info = fields[i];
                //Debug.Log("DeclaringType: " + info.DeclaringType);
                //Debug.Log("Name: " + info.Name);
                //Debug.Log("FieldType: " + info.FieldType);
                Type ty = typeof(int);
                if(info.FieldType == typeof(int))
                {
                    int value = (int)info.GetValue(data);
                    value = RTEditorGUI.IntField(new GUIContent(info.Name), value);
                    info.SetValue(data, value);
                }
                else if(info.FieldType == typeof(string))
                {
                    string value = (string)info.GetValue(data);
                    value = RTEditorGUI.TextField(new GUIContent(info.Name), value);
                    info.SetValue(data, value);
                }
            }
        }
        #endregion
    }
}
