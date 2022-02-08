using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement), typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackCooldown;

    private Movement _movement;
    private Health _health;
    private Coroutine _attack;

    public event Action Attacked;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_health.isAlive == false)
            return;

        if (TryAttack() == false)
            _movement.Move(_target.position);
    }

    public void Init(Transform target)
    {
        _target = target;
    }

    private bool TryAttack()
    {
        if (_attack != null)
            return true;

        if (Vector3.Distance(transform.position, _target.position) <= _attackDistance)
        {
            _attack = StartCoroutine(Attack());
            return true;
        }

        return false;
    }

    private IEnumerator Attack()
    {
        if (_target.TryGetComponent(out Health health))
            health.TakeDamage(_attackDamage);

        Attacked?.Invoke();

        yield return new WaitForSeconds(_attackCooldown);

        _attack = null;
    }
}