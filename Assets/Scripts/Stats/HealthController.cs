using DataProviding;
using System;
using Unity.Collections;
using UnityEngine;

namespace Characteristics
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void Awake()
        {
            _health.SetDefaultValue(DataProvider.GetData<StaticData>().PlayerTemplate.Health);
        }

        public void ApplyHealing(float healAmount)
        {
            _health.GetHealing(healAmount);
        }

        public void GetDamage(float damage)
        {
            _health.GetDamage(damage);
        }
    }
}