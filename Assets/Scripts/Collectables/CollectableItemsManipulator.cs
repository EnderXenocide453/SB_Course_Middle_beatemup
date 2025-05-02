using EffectsSystem;
using UnityEngine;

namespace Collectables
{
    public static class CollectableItemsManipulator
    {
        public static void Collect(Collector collector, CollectableItem item)
        {
            if (collector == null || item == null) {
                Debug.LogError("collector or item is null");
                return;
            }

            switch (item) {
                case CollectableEffect effect:
                    CollectEffect(collector, effect);
                    break;
                default:
                    Debug.LogError($"Collect function for {item.GetType()} not implemented");
                    return;
            }
        }

        private static void CollectEffect(Collector collector, CollectableEffect effect)
        {
            if (!collector.TryGetComponent<EffectableObject>(out var effectable))
                return;

            effect.Template.Apply(effectable);
            effect.OnCollect(collector);
        }
    }
}
