using UnityEngine;

namespace EffectsSystem
{
    [CreateAssetMenu(fileName = nameof(PermanentHealEffectTemplate), menuName = "Effects/" + nameof(PermanentHealEffectTemplate))]
    public class PermanentHealEffectTemplate : EffectTemplate
    {
        [SerializeField] protected float _healAmount; 

        public override void Apply(EffectableObject effectableObject)
        {
            effectableObject.TryApplyHealing(_healAmount);
        }

        public override void Remove(EffectableObject effectableObject) { }
    }
}