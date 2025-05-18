namespace AI
{
    public class WaitBehaviour : BaseAIBehaviour
    {
        public WaitBehaviour(EBehaviourType type) : base(type)
        {
        }

        public override float Evaluate(AIAgent agent) => Weight;
        public override void Execute(AIAgent agent) { }
    }
}