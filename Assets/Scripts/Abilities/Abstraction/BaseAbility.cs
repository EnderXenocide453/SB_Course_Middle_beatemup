using System.Collections;
using UnityEngine;

namespace Stats
{
    public abstract class BaseAbility : MonoBehaviour, IAbilityStarter
    {
        [SerializeField] protected float delay;

        protected bool _isReady = true;
        protected StatsHandler _statsHandler;

        public void Init(StatsHandler handler)
        {
            _statsHandler = handler;
        }

        public virtual void Execute()
        {
            if (_isReady) {
                UseAbility();
                StartCoroutine(Cooldown());
            }
        }

        protected virtual void OnReady()
        {
            _isReady = true;
        }

        protected abstract void UseAbility();

        protected IEnumerator Cooldown()
        {
            _isReady = false;
            yield return new WaitForSeconds(delay);

            OnReady();
        }
    }
}

