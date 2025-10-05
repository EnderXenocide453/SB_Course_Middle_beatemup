using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public class HideWhenFarFromSomethingAbility : MonoBehaviour, IPassiveAbility
    {
        private static readonly int value = Shader.PropertyToID("_Value");
        
        [SerializeField] private Transform[] _targets;
        [SerializeField] private float _distanceToStartHide = 1;
        [SerializeField] private float _distanceToCompletelyHide = 6;
        [SerializeField] private AnimationCurve _blinkCurve = AnimationCurve.Constant(0, 1, 0);
        [SerializeField] private float _blinkStartSpeed = 0;
        [SerializeField] private float _blinkEndSpeed = 0.1f;
        
        private List<Material> _myMaterials;
        private float _currentBlinkTime = 0;

        private void Start()
        {
            var renderers = GetComponentsInChildren<Renderer>();
            _myMaterials = new();
            foreach (var renderer in renderers)
                _myMaterials.Add(renderer.material);
        }
        
        private void Update()
        {
            float closest = GetClosestDistance();
            EvaluateHide(closest);
        }

        private float GetClosestDistance()
        {
            float closestSqr = Mathf.Infinity;
            foreach (var target in _targets)
            {
                var sqrMagnitude = (target.position - transform.position).sqrMagnitude;
                if (sqrMagnitude < closestSqr)
                    closestSqr = sqrMagnitude;
            }
            
            return Mathf.Sqrt(closestSqr);
        }

        private void EvaluateHide(float distance)
        {
            float hideValue = Mathf.InverseLerp(_distanceToStartHide, _distanceToCompletelyHide, distance);
            _currentBlinkTime += Mathf.Lerp(_blinkStartSpeed, _blinkEndSpeed, hideValue) * Time.deltaTime;
            var blinkValue = _blinkCurve.Evaluate(_currentBlinkTime);
            
            hideValue *= blinkValue;
            foreach (var material in _myMaterials)
                material.SetFloat(value, hideValue);
        }
    }
}