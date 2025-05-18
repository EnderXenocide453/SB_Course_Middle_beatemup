using UnityEngine;

namespace AI
{
    public class ChaseBehaviour : BaseAIBehaviour
    {
        public ChaseBehaviour(EBehaviourType type) : base(type)
        {
        }

        public override float Evaluate(AIAgent agent)
        {
            if (agent.Target == null && agent.IsDestinationReached)
                return float.MinValue;

            return Weight;
        }

        public override void Execute(AIAgent agent)
        {
            if (agent.Target != null)
                agent.Destination = agent.Target.position;
        }

        public override void OnEnter(AIAgent agent) { }

        public override void OnExit(AIAgent agent) { }
    }
}