using Stats;
using UnityEngine;

namespace Collectables
{
    public abstract class CollectableBuff : CollectableItem
    {
        [SerializeField] private BuffData _effectData;

        public abstract IBuff Buff { get; }
    }
}
