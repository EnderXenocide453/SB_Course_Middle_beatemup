using DataProviding;
using EffectsSystem;
using UnityEngine;

namespace Characteristics
{
    public class StatsHandler : MonoBehaviour
    {
        [SerializeField] private EffectableObject _effectable;
        [SerializeField] private EPlayerType _playerType;

        private PlayerTemplate _template;
        private StaticData StaticData => DataProvider.GetData<StaticData>();

        public float this[ECharacteristicType type]
        {
            get
            {
                if (_template == null)
                {
                    Debug.LogError("Template is not assigned!");
                    return 0;
                }
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

        private void Awake()
        {
            if (!StaticData.PlayerTemplates.TryGetValue(_playerType, out _template))
            {
                Debug.LogError("StaticData not found");
                return;
            }
            
            _effectable.Init(_template.Health);
        }
    }
}
