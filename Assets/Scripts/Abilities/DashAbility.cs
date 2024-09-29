using UnityEngine;

namespace Stats
{
    public class DashAbility : BaseAbility
    {
        [SerializeField] float force = 1;

        protected override void UseAbility()
        {
            transform.position += transform.forward * force;
        }
    }
}