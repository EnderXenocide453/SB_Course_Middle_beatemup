using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class KeepDistanceBehaviour : BaseAIBehaviour
    {
        public KeepDistanceBehaviour(EBehaviourType type) : base(type)
        {
        }

        public override float Evaluate(AIAgent agent)
        {
            if (agent.Target == null || agent.SqrDistanceToTarget > agent.SqrDistanceToAvoid)
                return float.MinValue;

            return Weight;
        }

        public override void Execute(AIAgent agent) { }

        public override void OnEnter(AIAgent agent)
        {
            Vector3 rawPosition = (agent.transform.position - agent.Target.position) + agent.transform.position;
            if (!NavMesh.SamplePosition(rawPosition, out NavMeshHit hit, float.MaxValue, NavMesh.AllAreas))
                return;
            
            agent.Destination = hit.position;
        }
    }
}