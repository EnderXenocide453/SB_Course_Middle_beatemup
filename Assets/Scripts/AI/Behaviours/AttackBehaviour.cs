using Abilities;
using UnityEngine;

namespace AI
{
    public class AttackBehaviour : BaseAIBehaviour
    {
        public AttackBehaviour(EBehaviourType type) : base(type)
        {
        }

        public override float Evaluate(AIAgent agent)
        {
            if (agent.Target == null || agent.SqrDistanceToTarget > agent.SqrDistanceToAttack ||
                !agent.TryGetAbility<ShootAbility>(out var shootAbility))
                return float.MinValue;

            return Weight;
        }

        public override void Execute(AIAgent agent)
        {
            agent.transform.LookAt(agent.Target);
        }

        public override void OnEnter(AIAgent agent)
        {
            if (!agent.TryGetAbility<ShootAbility>(out var shootAbility))
            {
                Debug.LogError($"Try to attack without ability");
                return;
            }
            
            shootAbility.Execute();
            agent.StopMovement();
        }

        public override void OnExit(AIAgent agent)
        {
            if (!agent.TryGetAbility<ShootAbility>(out var shootAbility))
                return;
            
            shootAbility.EndExecution();
        }
    }
}