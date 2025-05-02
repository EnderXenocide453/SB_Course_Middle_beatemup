using UnityEngine;

namespace Abilities
{
    public class ShootAbility : HoldAbility
    {
        [SerializeField] GameObject bulletPrefab;

        protected override void UseAbility()
        {
            var bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
            if (bulletObj.TryGetComponent<Bullet>(out var bullet))
                bullet.Init(_statsHandler);
        }
    }
}