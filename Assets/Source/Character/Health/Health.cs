using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [field: SerializeField] public uint MaxValue { get; private set; }
    
    public uint Value { get; private set; }

    public bool IsAlive => Value > 0;

    private void Awake()
    {
        Value = MaxValue;
    }

    public void TakeDamage(uint damage)
    {
        if (IsAlive == false)
            throw new InvalidOperationException();

        Value = (uint)Math.Clamp((int)Value - damage, 0, MaxValue);

        OnTakeDamage();

        if (Value == 0)
            Die();
    }

    protected virtual void OnTakeDamage() { }

    protected virtual void Die() { }
}

public interface IHealth : IDamagable
{
    bool IsAlive { get; }
}