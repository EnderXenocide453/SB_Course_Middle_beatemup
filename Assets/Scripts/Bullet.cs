using Stats;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const float lifeTime = 5;
    private StatsHandler _statsHandler;
    private int _ricochets;

    private void FixedUpdate()
    {
        if (_statsHandler != null)
            transform.position += transform.forward * _statsHandler[StatType.ProjectileSpeed] * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health)) {
            health.GetDamage(_statsHandler[StatType.Damage]);
        }
        if (_ricochets > 0) {
            Ricochet(collision);
            return;
        }
        Destroy(gameObject);
    }

    private void Ricochet(Collision collision)
    {
        Vector3 direction = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
        transform.LookAt(direction);
        _ricochets--;
    }

    public void Init(StatsHandler statsHandler)
    {
        _statsHandler = statsHandler;
        _ricochets = (int)statsHandler[StatType.Ricochet];
        StartCoroutine(LifeCycle());
    }

    private IEnumerator LifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
