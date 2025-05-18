using System;
using System.Collections.Generic;
using Abilities;
using AI.Senses;
using DataProviding;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        //Это всё по-хорошему должно храниться в PlayerTemplate
        [SerializeField] private List<EBehaviourType> _behaviourTypesList;
        [SerializeField] private float _distanceToAttack;
        [SerializeField] private float _minDistanceToAvoid;
        
        private readonly Dictionary<Type, BaseAbility> _abilities = new Dictionary<Type, BaseAbility>();
        private readonly Dictionary<ESenseType, Transform> _sensedTargets = new Dictionary<ESenseType, Transform>();
        private HashSet<EBehaviourType> _behaviourTypes;
        
        public int ID { get; set; }
        public HashSet<EBehaviourType> BehaviourTypes => _behaviourTypes;
        private AIGlobalData AIGlobalData => DataProvider.GetData<AIGlobalData>();

        #region Public parameters for system

        public Vector3 Destination
        {
            get => _navMeshAgent.destination;
            set => _navMeshAgent.destination = value;
        }
        public Transform Target { get; set; }

        public bool IsDestinationReached => !_navMeshAgent.hasPath || _navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete;
        public float SqrDistanceToTarget { get; set; }
        public float SqrDistanceToAttack => _distanceToAttack * _distanceToAttack;
        public float SqrDistanceToAvoid => _minDistanceToAvoid * _minDistanceToAvoid;
        public (IAIBehaviour behaviour, float timeStamp) CurrentBehaviour { get; set; }

        #endregion

        private void Awake()
        {
            _behaviourTypes = new HashSet<EBehaviourType>(_behaviourTypesList);
            
            var abilities = GetComponents<BaseAbility>();
            foreach (var ability in abilities)
                _abilities[ability.GetType()] = ability;
            
            AIGlobalData.RegisterAgent(this);
        }

        public bool TryGetAbility<T>(out T ability) where T : BaseAbility
        {
            ability = null;
            
            if (!_abilities.TryGetValue(typeof(T), out var rawAbility) || rawAbility is not T resultAbility)
                return false;
            
            ability = resultAbility;
            return true;
        }

        private void OnDestroy()
        {
            AIGlobalData.UnregisterAgent(this);
        }

        public void OnSenseVisibilityChanged(ESenseType senseType, Transform target)
        {
            _sensedTargets[senseType] = target;
            
            foreach (var sensedTarget in _sensedTargets.Values)
                if (sensedTarget != null)
                {
                    Target = target;
                    return;
                }
            
            Target = null;
        }

        public void StopMovement()
        {
            _navMeshAgent.ResetPath();
        }
    }
}