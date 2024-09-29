using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public class StatsHandler : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private StatInfo[] _baseStats;
        private Dictionary<StatType, float> _statsDict = new Dictionary<StatType, float>()
        {
            { StatType.Health, 10 },
            { StatType.Ricochet, 0 }
        };

        public Health Health => _health;

        public float this[StatType type]
        {
            get
            {
                if (!_statsDict.TryGetValue(type, out float value)) {
                    _statsDict.Add(type, 0);
                    value = 0;
                }
                return value;
            }
            set
            {
                if (!_statsDict.TryAdd(type, value)) {
                    _statsDict[type] = value;
                }
            }
        }

        private void OnValidate()
        {
            InitDict();
        }

        public void ApplyBuff(StatsBuff buff) => this[buff.Type] += buff.Value;
        
        public void CancelBuff(StatsBuff buff) => this[buff.Type] -= buff.Value;

        private void InitDict()
        {
            foreach(StatInfo info in _baseStats) {
                this[info.Type] = info.Value;
            }
        }

        [System.Serializable]
        private struct StatInfo
        {
            public StatType Type;
            public float Value;
        }
    }
}
