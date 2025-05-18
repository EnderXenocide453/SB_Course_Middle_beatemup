using System;
using DataProviding;
using UnityEngine;

namespace AI
{
    public class AIUtilitySystem : MonoBehaviour
    {
        private AIGlobalData _aiGlobalData;

        private void Awake()
        {
            _aiGlobalData = DataProvider.GetData<AIGlobalData>();
        }

        private void FixedUpdate()
        {
            IAIBehaviour primaryBehaviour;
            float highestValue;
            
            foreach (var agent in _aiGlobalData.Agents.Values)
            {
                highestValue = float.MinValue;
                primaryBehaviour = agent.CurrentBehaviour.behaviour;
                
                agent.SqrDistanceToTarget = agent.Target != null ? Vector3.SqrMagnitude(agent.Target.position - agent.transform.position) : 0;
                
                foreach (var behaviourType in agent.BehaviourTypes)
                {
                    if (!_aiGlobalData.AIBehaviours.TryGetValue(behaviourType, out var behaviour))
                    {
                        Debug.LogError($"Behaviour of type {primaryBehaviour.GetType()} was not found");
                        continue;
                    }

                    var value = behaviour.Evaluate(agent);
                    if (value <= highestValue)
                        continue;
                    
                    highestValue = value;
                    primaryBehaviour = behaviour;
                }
                
                if (agent.CurrentBehaviour.behaviour != primaryBehaviour)
                {
                    if (agent.CurrentBehaviour.behaviour != null)
                        agent.CurrentBehaviour.behaviour.OnExit(agent);
                    if (primaryBehaviour != null)
                        primaryBehaviour.OnEnter(agent);
                    
                    agent.CurrentBehaviour = (primaryBehaviour, Time.time);
                }
                
                primaryBehaviour?.Execute(agent);
            }
        }
    }
}