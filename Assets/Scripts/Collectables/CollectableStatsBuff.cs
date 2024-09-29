using Stats;
using UnityEngine;

namespace Collectables
{
    public class CollectableStatsBuff : CollectableBuff
    {
        [SerializeField] private StatType _type;
        [SerializeField] private float _value;
        [SerializeField] private BuffData _data;
        
        public override IBuff Buff => new StatsBuff(_type, _value, _data);
    }
}
