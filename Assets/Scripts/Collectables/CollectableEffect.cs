using Characteristics;
using EffectsSystem;
using System;
using UnityEngine;

namespace Collectables
{
    public class CollectableEffect : CollectableItem
    {
        [SerializeField] private EffectTemplate _effectTemplate;
        [SerializeField] private MeshRenderer _meshRenderer;

        public EffectTemplate Template => _effectTemplate;

        private void OnEnable()
        {
            if (_effectTemplate == null) {
                Debug.LogError("effect template is null!");
                return;
            }

            SetTemplate(_effectTemplate);
        }

        public void SetTemplate(EffectTemplate effectTemplate)
        {
            _effectTemplate = effectTemplate;
            _meshRenderer.material.color = effectTemplate.Color;
        }
    }
}
