using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [NodeCanvasType("Skill Canvas")]
    public class SkillCanvasType : NodeCanvas
    {
        public override string canvasName { get { return "Skill"; } }

        private string rootNodeID { get { return "rootSkillNode"; } }
        public RootSkillNode rootNode;

        protected override void OnCreate()
        {
            Traversal = new SkillTraversal(this);
            rootNode = Node.Create(rootNodeID, Vector2.zero, this, null, true) as RootSkillNode;
        }

        private void OnEnable()
        {
            if (Traversal == null)
                Traversal = new SkillTraversal(this);
            // Register to other callbacks
            //NodeEditorCallbacks.OnDeleteNode += CheckDeleteNode;
        }

        protected override void ValidateSelf()
        {
            if (Traversal == null)
                Traversal = new SkillTraversal(this);
            if (rootNode == null && (rootNode = nodes.Find((Node n) => n.GetID == rootNodeID) as RootSkillNode) == null)
                rootNode = Node.Create(rootNodeID, Vector2.zero, this, null, true) as RootSkillNode;
        }

        public override bool CanAddNode(string nodeID)
        {
            //Debug.Log ("Check can add node " + nodeID);
            if (nodeID == rootNodeID)
                return !nodes.Exists((Node n) => n.GetID == rootNodeID);
            return true;
        }
    }
}
