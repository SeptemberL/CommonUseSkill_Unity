using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using TSystem;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
    [Node(false, "Skill/Trigger Node")]
    public class TriggerNode : Node
    {
        public const string Name = "Trigger";

        public const string ID = "TriggerNode";
        public override string GetID { get { return ID; } }
        public override string Title { get { return "触发器";} }
        //public override Vector2 DefaultSize { get { return DefaultSize; }  }

        [ConnectionKnob("In", Direction.In, Name, NodeSide.Left, 10)]
        public ConnectionKnob flowIn;

        TriggerData triggerData = new TriggerData();

        public override void NodeGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
            /*
            TActionType type = (TActionType)RTEditorGUI.EnumPopup(new GUIContent("命令类型", "命令类型"), actionData.GetDataType());
            if(type != actionData.GetDataType())
            {
                actionData = TActionFactory.CreateTActionData(type);
            }

            if(type == TActionType.TACTION_DO_DAMAGE)
            {
                DefaultSize = new Vector2(300, 500);
            }
*/
            DefaultSize = new Vector2(DefaultWidth, TDataVarManager.DrawTDataVars(triggerData) + DefaultHeight);
            // Get adjacent flow elements
            Node flowSource = flowIn.connected() ? flowIn.connections[0].body : null;
            //List<Node> flowTargets = flowOut.connections.Select((ConnectionKnob input) => input.body).ToList();

            // Display adjacent flow elements
            GUILayout.Label("Flow Source: " + (flowSource != null ? flowSource.name : "null"));
            GUILayout.Label("Flow Targets:");
            //foreach (Node flowTarget in flowTargets)
            //   GUILayout.Label("-> " + flowTarget.name);
        }

        public override bool Calculate()
        {
            //outputKnob.SetValue<float>(inputKnob.GetValue<float>() * 5);
            return true;
        }
    }

    // Flow connection visual style
    public class TriggerConnection : ConnectionKnobStyle
    {
        public override string Identifier { get { return TriggerNode.Name; } }
        public override Color Color { get { return Color.red; } }
    }
}