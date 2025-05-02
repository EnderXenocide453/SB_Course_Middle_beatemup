using Characteristics;
using General;
using UnityEngine;

namespace EffectsSystem
{
    [CreateAssetMenu(fileName = nameof(CharacteristicsEffectTemplate), menuName = "Effects/" + nameof(CharacteristicsEffectTemplate))]
    public class CharacteristicsEffectTemplate : EffectTemplate
    {
        [SerializeField] protected ECharacteristicType _characteristic;
        [SerializeField] protected float _characteristicModifier;

        public override void Apply(EffectableObject effectableObject)
        {
            effectableObject.TryApplyModifier(_characteristic, _characteristicModifier);
        }

        public override void Remove(EffectableObject effectableObject)
        {
            effectableObject.TryRemoveModifier(_characteristic, _characteristicModifier);
        }
    }
}