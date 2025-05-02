using Characteristics;
using System;
using UnityEngine;

namespace Collectables
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent<CollectableItem>(out var item)) {
                CollectableItemsManipulator.Collect(this, item);
            }
        }
    }
}
