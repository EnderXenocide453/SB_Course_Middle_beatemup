using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class PatrolBehaviour : BaseAIBehaviour
    {
        public const float BEHAVIOUR_COOLDOWN = 2.0f;

        public const float MIN_PATROLING_RADIUS = 5f;
        public const float MAX_PATROLING_RADIUS = 10f;

        public PatrolBehaviour(EBehaviourType type) : base(type)
        {
        }

        public override float Evaluate(AIAgent agent)
        {
            var currentBehaviour = agent.CurrentBehaviour;
            var isCooldownEnds = Time.time - currentBehaviour.timeStamp > BEHAVIOUR_COOLDOWN;
            var isSameBehaviour = currentBehaviour.behaviour == this;

            if (!isSameBehaviour)
                return isCooldownEnds ? Weight : float.MinValue;

            return agent.IsDestinationReached ? float.MinValue : Weight;
        }

        public override void Execute(AIAgent agent) { }

        public override void OnEnter(AIAgent agent)
        {
            var direction = Random.insideUnitCircle * Random.Range(MIN_PATROLING_RADIUS, MAX_PATROLING_RADIUS);
            Vector3 rawPosition = new Vector3(direction.x, 0, direction.y) + agent.transform.position;
            if (!NavMesh.SamplePosition(rawPosition, out NavMeshHit hit, float.MaxValue, NavMesh.AllAreas))
                return;
            
            agent.Destination = hit.position;
        }
    }
}