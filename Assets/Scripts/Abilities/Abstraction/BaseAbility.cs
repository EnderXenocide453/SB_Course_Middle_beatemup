using Characteristics;
using System.Collections;
using UnityEngine;

namespace Abilities
{
    public abstract class BaseAbility : MonoBehaviour, IAbilityStarter
    {
        [SerializeField] protected float delay;

        protected bool _isReady = true;
        protected StatsHandler _statsHandler;

        private void Awake()
        {
            _statsHandler = GetComponent<StatsHandler>();
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

