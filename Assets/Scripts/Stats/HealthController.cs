using DataProviding;
using System;
using Unity.Collections;
using UnityEngine;

namespace Characteristics
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public Health Health => _health;
        
        public void Init(float health)
        {
            _health.SetDefaultValue(health);
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