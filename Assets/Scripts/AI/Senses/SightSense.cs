using System;
using UnityEngine;

namespace AI.Senses
{
    public class SightSense : AbstractSense
    {
        [SerializeField] private float _sightDistance;
        [SerializeField] private float _sightAngle;
        [SerializeField] private LayerMask _sightOcclusionMask;

        private bool _isOccluded;
        private Vector3 _occludedPoint;
        
        protected override ESenseType SenseType => ESenseType.Sight;

        private void OnDrawGizmos()
        {
            Gizmos.color = IsTargetVisible ? Color.green : Color.red;
            if (_isOccluded)
                Gizmos.DrawLine(transform.position, _occludedPoint);
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(_sightAngle / 2, Vector3.up) * transform.forward * _sightDistance);
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(-_sightAngle / 2, Vector3.up) * transform.forward * _sightDistance);
        }

        private void FixedUpdate()
        {
            var isVisible = IsNear() && IsInFOV() && IsNotOccluded();
            if (isVisible != IsTargetVisible)
                SetTargetVisibility(isVisible);
        }

        private bool IsNotOccluded()
        {
            Ray ray = new Ray(transform.position, Target.transform.position - transform.position);
            _isOccluded = Physics.Raycast(ray, out var hit, Vector3.Distance(transform.position, Target.transform.position), _sightOcclusionMask);
            _occludedPoint = hit.point;
            
            return !_isOccluded;
        }

        private bool IsInFOV()
        {
            return Vector3.Angle(transform.forward, Target.transform.position - transform.position) < _sightAngle / 2;
        }

        private bool IsNear()
        {
            return (transform.position - Target.transform.position).sqrMagnitude < _sightDistance * _sightDistance;
        }
    }
}