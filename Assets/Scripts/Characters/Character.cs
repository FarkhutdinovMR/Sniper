using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Movement), typeof(Health))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _stopingDistance;

    private Movement _movement;
    private Health _health;

    public event UnityAction ReachedSafeArea;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_health.isAlive == false)
            return;

        if (Vector3.Distance(transform.position, _target.position) > _stopingDistance)
            _movement.Move(_target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SafeArea safeArea))
            ReachedSafeArea?.Invoke();
    }
}