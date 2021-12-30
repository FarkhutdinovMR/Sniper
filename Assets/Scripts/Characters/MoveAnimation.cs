using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Movement), typeof(Health))]
public class MoveAnimation : MonoBehaviour
{
    protected Animator _animator;

    private Movement _movement;
    private Health _health;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
    }

    protected virtual void OnEnable()
    {
        _movement.Moved += OnMoved;
        _health.Dies += OnDies;
    }

    protected virtual void OnDisable()
    {
        _movement.Moved -= OnMoved;
        _health.Dies -= OnDies;
    }

    private void OnMoved(float speed)
    {
        _animator.SetFloat(AnimatorCharacterController.Params.Speed, speed);
    }

    private void OnDies()
    {
        _animator.SetTrigger(AnimatorCharacterController.States.Death);
    }
}