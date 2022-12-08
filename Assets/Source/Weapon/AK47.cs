using UnityEngine;

public class AK47 : Weapon
{
    [SerializeField] private MonoBehaviour _targetHealthSource;
    private IHealth _targetHealth => (IHealth)_targetHealthSource;

    [SerializeField] private uint _accuracyInPercent;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    protected override void OnShoot()
    {
        float hit—hance = Random.Range(0, 100);
        if (hit—hance <= _accuracyInPercent && _targetHealth.IsAlive)
            _targetHealth.TakeDamage(Damage);

        _enemyAnimator.Shoot();
    }

    private void OnValidate()
    {
        if (_targetHealthSource && !(_targetHealthSource is IHealth))
        {
            Debug.LogError(nameof(_targetHealthSource) + "is not implement " + nameof(IHealth));
            _targetHealthSource = null;
        }
    }
}