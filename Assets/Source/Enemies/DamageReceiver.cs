using UnityEngine;

public class DamageReceiver : MonoBehaviour, IDamagable
{
    [SerializeField] private float _damageMultiplier = 1f;
    [SerializeField] private MonoBehaviour _healthSource;
    private IHealth _health => (IHealth)_healthSource;

    public void TakeDamage(uint damage)
    {
        if (_health.IsAlive)
            _health.TakeDamage((uint)(damage * _damageMultiplier));
    }

    private void OnValidate()
    {
        if (_healthSource && !(_healthSource is IHealth))
        {
            Debug.LogError(nameof(_healthSource) + "is not implement " + nameof(IHealth));
            _healthSource = null;
        }
    }
}