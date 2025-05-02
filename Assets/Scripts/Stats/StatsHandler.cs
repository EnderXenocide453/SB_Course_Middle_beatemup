using DataProviding;
using EffectsSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    public class StatsHandler : MonoBehaviour
    {
        [SerializeField] private EffectableObject _effectable;

        private PlayerTemplate _template => DataProvider.GetData<StaticData>().PlayerTemplate;

        public float this[ECharacteristicType type]
        {
            get
            {
                if (!_template.Characteristics.TryGetValue(type, out float value)) {
                    Debug.LogError($"Characteristic of type {type} not implemented in template, return 0");
                    return 0;
                }
                return _effectable.EffectCharacteristic(type, value);
            }
        }

        [System.Serializable]
        private struct StatInfo
        {
            public ECharacteristicType Type;
            public float Value;
        }
    }
}
