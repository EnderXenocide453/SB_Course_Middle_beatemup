using UnityEngine;
using UnityEngine.Events;

namespace Collectables
{
    public abstract class CollectableItem : MonoBehaviour
    {
        public virtual void OnCollect(Collector collector)
        {
            Destroy(gameObject);
        }
    }
}
