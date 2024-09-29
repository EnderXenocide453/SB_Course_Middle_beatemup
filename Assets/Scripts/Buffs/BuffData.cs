using UnityEngine;

namespace Stats
{
    [System.Serializable]
    public struct BuffData
    {
        public string Name;
        public Sprite Icon;
        /// <summary>
        /// Продолжительность действия эффекта. Если отрицательна, эффект считается постоянным
        /// </summary>
        public float Duration;
    }
}
