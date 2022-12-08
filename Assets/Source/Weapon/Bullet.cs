using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _pushForce;
    [SerializeField] private uint _damage;

    private Transform _camera;

    public void Init(Transform camera)
    {
        _camera = camera;
    }

    private void Start()
    {
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.TryGetComponent(out IDamagable health))
                    health.TakeDamage(_damage);

            if (hitInfo.rigidbody != null)
                Push(hitInfo);

            Debug.Log(hitInfo.transform.name);
        }

        Destroy(gameObject);
    }

    private void Push(RaycastHit hitInfo)
    {
        Vector3 direction = (hitInfo.point - _camera.position).normalized;
        hitInfo.rigidbody.AddForce(direction * _pushForce, ForceMode.Impulse);
    }
}