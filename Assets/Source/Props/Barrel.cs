using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IDamagable
{
    [SerializeField] private uint _damage;
    [SerializeField] private float _radius;
    [SerializeField] private GameObject _sfx;

    public void TakeDamage(uint damage)
    {
        BlowUp();
        Instantiate(_sfx, transform.position, Quaternion.identity);
    }

    private void BlowUp()
    {
        IEnumerable<IDamagable> damagables = new GetObjectsInRadius<IDamagable>(_radius, transform).Get();
        foreach (IDamagable damagable in damagables)
            damagable.TakeDamage(_damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}