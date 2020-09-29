using UnityEngine;
using NodeEditorFramework.Utilities;
using System.Reflection;
using System.CodeDom;
using System;
using TSystem;
using System.Collections.Generic;

namespace NodeEditorFramework.Standard
{
    [Node(false, "Skill/Skill Root")]
    [Serializable]
    public class RootSkillNode : Node
    {
        public const string ID = "rootSkillNode";
        public override string GetID { get { return ID; } }

        public override string Title { get { return "技能模板"; } }
        public override Vector2 DefaultSize { get { return new Vector2(150, 100); } }

        //[ConnectionKnob("Triggers", Direction.Out, TriggerNode.Name)]
        //public ConnectionKnob triggers;

        private ValueConnectionKnobAttribute triggerCreationAttribute = new ValueConnectionKnobAttribute("Out", Direction.Out, "Trigger", ConnectionCount.Single);
        [SerializeField]
        public SkillData SkillData;
        public List<TriggerNode> triggerNodes = new List<TriggerNode>();

        public override void NodeGUI()
        {
            if (SkillData == null)
                SkillData = new SkillData();
            bool uiChanged = false;
            DefaultSize = new Vector2(DefaultWidth, TDataVarManager.DrawTDataVars(SkillData,ref uiChanged) + DefaultHeight);
            if(uiChanged)
            {
                
            }

            if (dynamicConnectionPorts.Count != SkillData.Triggers.Count)
            { // Make sure labels and ports are synchronised
                while (dynamicConnectionPorts.Count > SkillData.Triggers.Count)
                    DeleteConnectionPort(dynamicConnectionPorts.Count - 1);
                while (dynamicConnectionPorts.Count < SkillData.Triggers.Count)
                    CreateValueConnectionKnob(triggerCreationAttribute);
            }

            //FlushData();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add", GUILayout.ExpandWidth(false)))
            {
                SkillData.Triggers.Add(new TriggerData());
                 CreateValueConnectionKnob(triggerCreationAttribute);
            }
            GUILayout.EndHorizontal();

            for (int i = 0; i < SkillData.Triggers.Count; i++)
            { // Display label and delete button
                GUILayout.BeginHorizontal();
                GUILayout.Label(SkillData.Triggers[i].TriggerDesc);
                ((ValueConnectionKnob)dynamicConnectionPorts[i]).SetPosition();
                if (GUILayout.Button("x", GUILayout.ExpandWidth(false)))
                { // Remove current label
                    SkillData.Triggers.RemoveAt(i);
                    DeleteConnectionPort(i);
                    i--;
                }
                GUILayout.EndHorizontal();
            }


        }

        public override bool Calculate() 
        {
            for (int i = 0; i < dynamicConnectionPorts.Count; i++)
            {
                ConnectionPort port = dynamicConnectionPorts[i];
                if (port.connected())
                {
                    ConnectionPort subPort = port.connections[0];
                    TriggerNode tn = (TriggerNode)subPort.body;
                    tn.triggerData = SkillData.Triggers[i];
                }
            }
            return true;
        }

        protected internal override void OnAddConnection(ConnectionPort port, ConnectionPort connection)
        {
            base.OnAddConnection(port, connection);
            FlushData();
        }

        protected internal override void OnRemoveConnection(ConnectionPort port, ConnectionPort connection)
        {
            base.OnRemoveConnection(port, connection);
            FlushData();
        }

        protected override void FlushData()
        {
            SkillData.Triggers.Clear();
            triggerNodes.Clear();
            for (int i =0; i < dynamicConnectionPorts.Count; i++)
            {
                ConnectionPort port = dynamicConnectionPorts[i];
                if(port.connected())
                {
                    ConnectionPort subPort = port.connections[0];
                    TriggerNode tn = (TriggerNode)subPort.body;
                    SkillData.Triggers.Add(tn.triggerData);
                }
            }
        }

        public void FlushTrigger(TriggerNode node)
        {
            for (int i = 0; i < dynamicConnectionPorts.Count; i++)
            {
                ConnectionPort port = dynamicConnectionPorts[i];
                if (port.connected())
                {
                    ConnectionPort subPort = port.connections[0];
                    TriggerNode tn = (TriggerNode)subPort.body;
                    if (tn == node)
                    {
                        SkillData.Triggers[i] = tn.triggerData;
                        break;
                    }
                }
            }
        }
    }
}
