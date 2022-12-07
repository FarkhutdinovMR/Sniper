using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _pushForce;

    private Transform _camera;

    public void Init(Transform camera)
    {
        _camera = camera;
    }

    private void Start()
    {
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(0);

            if (hitInfo.rigidbody != null)
                Push(hitInfo);
        }

        Destroy(gameObject);
    }

    private void Push(RaycastHit hitInfo)
    {
        Vector3 direction = (hitInfo.point - _camera.position).normalized;
        hitInfo.rigidbody.AddForce(direction * _pushForce, ForceMode.Impulse);
    }
}