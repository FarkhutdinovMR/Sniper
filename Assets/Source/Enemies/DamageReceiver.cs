using UnityEngine;

public class DamageReceiver : MonoBehaviour, IDamagable
{
    [SerializeField] private MonoBehaviour _damagableSource;
    private IDamagable _damagable => (IDamagable)_damagableSource;

    public void TakeDamage(uint damage)
    {
        _damagable.TakeDamage(damage);
    }

    private void OnValidate()
    {
        if (_damagableSource && !(_damagableSource is IDamagable))
        {
            Debug.LogError(nameof(_damagableSource) + "is not implement " + nameof(IDamagable));
            _damagableSource = null;
        }
    }
}

public interface IDamagable
{
    void TakeDamage(uint damage);
}