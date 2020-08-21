using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using NodeEditorFramework;

namespace NodeEditorFramework.Standard
{
    [CustomEditor(typeof(RTCanvasSkill))]
    public class RTCanvasSkillEditor : Editor
    {
        public RTCanvasSkill RTCalc;

        public List<Node> inputNodes;

        public void OnEnable()
        {
            RTCalc = (RTCanvasSkill)target;
        }

        public override void OnInspectorGUI()
        {
            RTCalc.canvas = EditorGUILayout.ObjectField("Canvas", RTCalc.canvas, typeof(NodeCanvas), false) as NodeCanvas;
            if (RTCalc.canvas == null)
                return;

            if (GUILayout.Button("Calculate and debug Output"))
                RTCalc.CalculateCanvas();

            DisplayInputValues();
        }

        private void DisplayInputValues()
        {
            if (inputNodes == null)
                inputNodes = RTCalc.getInputNodes();
            foreach (Node inputNode in inputNodes)
            {
                string outValueLog = "(IN) " + inputNode.name + ": ";
                foreach (ValueConnectionKnob knob in inputNode.outputKnobs.OfType<ValueConnectionKnob>())
                    outValueLog += knob.styleID + " " + knob.name + " = " + (knob.IsValueNull ? "NULL" : knob.GetValue().ToString()) + "; ";
                GUILayout.Label(outValueLog);
            }
        }
    }
}
