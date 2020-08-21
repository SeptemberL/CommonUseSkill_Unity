namespace NodeEditorFramework.Standard
{
    public class SkillTraversal : NodeCanvasTraversal
    {
        SkillCanvasType Canvas;

        public SkillTraversal(SkillCanvasType canvas) : base(canvas)
        {
            Canvas = canvas;
        }

        /// <summary>
        /// Traverse the canvas and evaluate it
        /// </summary>
        public override void TraverseAll()
        {
            RootSkillNode rootNode = Canvas.rootNode;
            rootNode.Calculate();
            //Debug.Log ("RootNode is " + rootNode);
        }
    }
}

