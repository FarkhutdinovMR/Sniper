using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAnimation : MoveAnimation
{
    private Enemy _enemy;

    protected override void Awake()
    {
        base.Awake();

        _enemy = GetComponent<Enemy>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _enemy.Attacked += OnAttacked;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _enemy.Attacked -= OnAttacked;
    }

    private void OnAttacked()
    {
        _animator.SetTrigger(AnimatorCharacterController.States.Attack);
    }
}