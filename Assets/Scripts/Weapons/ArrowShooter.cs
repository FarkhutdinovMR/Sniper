using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArrowShooter : MonoBehaviour, IShooter
{
    [SerializeField] private float _damage;
    [SerializeField] private float _puchForce;
    [SerializeField] private float _destroyTime;
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _rayDistance;
    [SerializeField] private Transform _head;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody _rigidbody;
    private Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        if (_rigidbody.velocity == Vector3.zero)
            return;

        ÑheckÑollisions();
    }

    public void Shoot()
    {
        Vector3 velocity = _camera.transform.forward * _startSpeed;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit))
            velocity = CalculateTrajectory(transform, hit.point);

        _rigidbody.isKinematic = false;
        _rigidbody.velocity = velocity;
        transform.parent = null;
    }

    private void Push(GameObject target)
    {
        if (target.TryGetComponent(out Rigidbody rigidbody))
        {
            Vector3 direction = (target.transform.position - _camera.transform.position).normalized;
            rigidbody.AddForce(direction * _puchForce, ForceMode.Impulse);
        }
    }

    private void ÑheckÑollisions()
    {
        if (Physics.Raycast(_head.position, _head.forward, out RaycastHit hit, _rayDistance, _layerMask))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            transform.position = hit.point;

            if (hit.collider.TryGetComponent(out Health health))
                health.TakeDamage(_damage);

            Push(hit.collider.gameObject);
        }
    }

    private Vector3 CalculateTrajectory(Transform startPoint, Vector3 target)
    {
        float v2 = _startSpeed * _startSpeed;
        float gravity = Physics.gravity.y;
        float angle;

        // Âûñîòà öåëè
        float height = startPoint.position.y - target.y;

        // Ðàññòîÿíèå äî òî÷êè ïîä öåëüþ
        float xx = target.x - startPoint.position.x;
        float xz = target.z - startPoint.position.z;
        float x = Mathf.Sqrt(xx * xx + xz * xz);

        float sqrt = (v2 * v2) - (gravity * (gravity * (x * x) + 2 * height * v2));

        // Not enough range
        if (sqrt < 0)
            return Vector3.zero;

        sqrt = Mathf.Sqrt(sqrt);

        angle = Mathf.Atan((v2 - sqrt) / (gravity * x));

        Quaternion q = Quaternion.Euler(angle * Mathf.Rad2Deg, startPoint.eulerAngles.y, startPoint.eulerAngles.z);

        return (q * Vector3.forward * _startSpeed);
    }
}