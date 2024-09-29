using UnityEngine;

namespace Stats
{
    [System.Serializable]
    public class Health
    {
        [SerializeField] private float _healthPoints;

        public void GetHealing(float amount)
        {
            _healthPoints += amount;
        }

        public void GetDamage(float amount)
        {
            _healthPoints -= amount;
        }
    }
}
