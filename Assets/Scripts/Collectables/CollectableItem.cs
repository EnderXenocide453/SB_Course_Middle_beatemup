using UnityEngine;
using UnityEngine.Events;

namespace Collectables
{
    public abstract class CollectableItem : MonoBehaviour
    {
        public UnityEvent OnCollect;

        public void Collect()
        {
            OnCollect?.Invoke();
        }
    }
}
