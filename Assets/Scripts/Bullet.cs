using Characteristics;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private StatsHandler _statsHandler;
    private int _ricochets;
    private float _damage;
    private float _speed;

    private Rigidbody _body;
    private Vector3 _direction;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<HealthController>(out var health)) {
            health.GetDamage(_damage);
            Destroy(gameObject);
            return;
        }
        if (_ricochets > 0) {
            Ricochet(collision);
            return;
        }
        Destroy(gameObject);
    }

    private void Ricochet(Collision collision)
    {
        _direction = Vector3.Reflect(_direction, collision.contacts[0].normal);
        transform.LookAt(_direction);
        _body.velocity = _direction * _speed;
        _ricochets--;
    }

    public void Init(StatsHandler statsHandler)
    {
        _statsHandler = statsHandler;
        _ricochets = (int)statsHandler[ECharacteristicType.Ricochet];
        _damage = statsHandler[ECharacteristicType.Damage];
        _speed = statsHandler[ECharacteristicType.ProjectileSpeed];

        _direction = transform.forward;
        _body.velocity = _speed * _direction;
    }
}
