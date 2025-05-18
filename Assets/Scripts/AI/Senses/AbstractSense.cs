using DataProviding;
using UnityEngine;

namespace AI.Senses
{
    [RequireComponent(typeof(AIAgent))]
    public abstract class AbstractSense : MonoBehaviour
    {
        protected AIAgent _agent;
        protected AITarget Target => DataProvider.GetData<AIGlobalData>().Target; 
        protected bool IsTargetVisible { get; private set; }

        protected abstract ESenseType SenseType { get; }
        
        private void Awake()
        {
            _agent = GetComponent<AIAgent>();
        }

        protected void SetTargetVisibility(bool isVisible)
        {
            _agent.OnSenseVisibilityChanged(SenseType, isVisible ? Target.transform : null);
            IsTargetVisible = isVisible;
        }
    }

    public enum ESenseType
    {
        Sight
    }
}