using Characteristics;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EffectsSystem
{
    public class EffectableObject : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        private readonly Dictionary<ECharacteristicType, float> _characteristicModifiers = new Dictionary<ECharacteristicType, float>();

        public void Init(float health)
        {
            _healthController.Init(health);
        }
        
        public void TryApplyHealing(float healAmount)
        {
            _healthController?.ApplyHealing(healAmount);
        }

        public void TryApplyModifier(ECharacteristicType characteristic, float characteristicModifier)
        {
            _characteristicModifiers[characteristic] =
                _characteristicModifiers.TryGetValue(characteristic, out float value) ? 
                value + characteristicModifier : 
                characteristicModifier;
        }

        public void TryRemoveModifier(ECharacteristicType characteristic, float characteristicModifier)
        {
            _characteristicModifiers[characteristic] =
                _characteristicModifiers.TryGetValue(characteristic, out float value) ?
                value - characteristicModifier :
                characteristicModifier;
        }

        public float EffectCharacteristic(ECharacteristicType type, float value)
        {
            if (_characteristicModifiers.TryGetValue(type, out var modifier))
                return value + modifier;

            _characteristicModifiers[type] = 0;
            return value;
        }
    }
}