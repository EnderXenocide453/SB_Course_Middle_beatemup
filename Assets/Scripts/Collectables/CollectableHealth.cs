using Stats;
using UnityEngine;

namespace Collectables
{
    public class CollectableHealth : CollectableBuff
    {
        [SerializeField] private float _value;
        [SerializeField] private BuffData _data;

        public override IBuff Buff => new HealthBuff(_value, _data);
    }
}
