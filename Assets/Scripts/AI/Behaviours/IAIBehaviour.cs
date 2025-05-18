using DataProviding;
using UnityEngine;

namespace AI
{
    public interface IAIBehaviour
    {
        public float Weight { get; set; }
        public EBehaviourType Type { get; set; }
        
        public float Evaluate(AIAgent agent);
        public void Execute(AIAgent agent);
        public void OnEnter(AIAgent agent);
        public void OnExit(AIAgent agent);
    }

    public abstract class BaseAIBehaviour : IAIBehaviour
    {
        public float Weight { get; set; }
        public EBehaviourType Type { get; set; }
        
        private StaticData StaticData => DataProvider.GetData<StaticData>();

        public BaseAIBehaviour(EBehaviourType type)
        {
            Type = type;
            if (StaticData.BaseBehaviourWeights.TryGetValue(type, out var weight))
                Weight = weight;
            else
            {
                Weight = 0;
                Debug.LogError($"Weight for behaviour type {type} not found. Set to zero");
            }
        }
        
        public abstract float Evaluate(AIAgent agent);
        public abstract void Execute(AIAgent agent);

        public virtual void OnEnter(AIAgent agent) { }
        public virtual void OnExit(AIAgent agent) { }
    }
}