using UnityEngine;

public class BulletShooter : MonoBehaviour, IShooter
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private bool isFly;

    public void Shoot()
    {
        transform.parent = null;
        isFly = true;
    }

    private void Update()
    {
        if (isFly)
            transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
            health.TakeDamage(_damage);
    }
}