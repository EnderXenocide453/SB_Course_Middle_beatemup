using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public class BuffsHandler : MonoBehaviour
    {
        [SerializeField] private StatsHandler _statsHandler;
        private List<IBuff> _buffs = new List<IBuff>();

        private void Update()
        {
            UpdateBuffs();
        }

        public void ApplyBuff(IBuff buff)
        {
            if (buff is StatsBuff statsBuff)
                _statsHandler.ApplyBuff(statsBuff);
            else if (buff is HealthBuff healthBuff)
                _statsHandler.Health.GetHealing(healthBuff.Value);

            _buffs.Add(buff);
        }

        public void CancelBuff(IBuff buff)
        {
            if (buff is StatsBuff statsBuff)
                _statsHandler.CancelBuff(statsBuff);
            else if (buff is HealthBuff healthBuff)
                _statsHandler.Health.GetDamage(healthBuff.Value);

            _buffs.Remove(buff);
        }

        public void CancelBuff(int id)
        {
            if (id < 0 || id >= _buffs.Count) return;

            var buff = _buffs[id];
            CancelBuff(buff);
        }

        private void UpdateBuffs()
        {
            for (int i = _buffs.Count - 1; i >= 0; i--) {
                var buff = _buffs[i];
                buff.Elapsed += Time.deltaTime;
                if (buff.Elapsed >= buff.BuffData.Duration)
                    CancelBuff(i);
            }
        }
    }
}
