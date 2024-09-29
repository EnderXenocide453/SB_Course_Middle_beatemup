using Stats;
using UnityEngine;

namespace Collectables
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private BuffsHandler _buffsHandler;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent<CollectableItem>(out var item)) {
                Collect(item);
            }
        }

        public void Collect(CollectableItem item)
        {
            if (item is CollectableBuff buff) {
                _buffsHandler.ApplyBuff(buff.Buff);
            }
        }
    }
}
