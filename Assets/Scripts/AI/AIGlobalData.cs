using System.Collections.Generic;
using DataProviding;
using UnityEngine;

namespace AI
{
    public class AIGlobalData : IDataContainer
    {
        public readonly Dictionary<int, AIAgent> Agents = new();
        public Dictionary<EBehaviourType, IAIBehaviour> AIBehaviours;

        private int _idsUsed;
        private readonly Queue<int> _freeIndices = new Queue<int>();
        public AITarget Target { get; set; }

        public void Init()
        {
            AIBehaviours = new Dictionary<EBehaviourType, IAIBehaviour>()
            {
                { EBehaviourType.Wait, new WaitBehaviour(EBehaviourType.Wait) },
                { EBehaviourType.Patrol, new PatrolBehaviour(EBehaviourType.Patrol) },
                { EBehaviourType.Chase, new ChaseBehaviour(EBehaviourType.Chase) },
                { EBehaviourType.Attack, new AttackBehaviour(EBehaviourType.Attack) },
                { EBehaviourType.KeepDistance, new KeepDistanceBehaviour(EBehaviourType.KeepDistance) },
            };
        }
        
        private int GetNextId()
        {
            if (_freeIndices.Count > 0)
                return _freeIndices.Dequeue();

            int id = _idsUsed;
            _idsUsed++;
            return id;
        }
        
        public void RegisterAgent(AIAgent agent)
        {
            agent.ID = GetNextId();
            Agents.Add(agent.ID, agent);
        }

        public void UnregisterAgent(AIAgent agent)
        {
            Agents.Remove(agent.ID);
            _freeIndices.Enqueue(agent.ID);
        }
    }
}