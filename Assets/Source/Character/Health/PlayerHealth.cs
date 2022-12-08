using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private MonoBehaviour _healthViewSource;
    private IHealthView _healthView => (IHealthView)_healthViewSource;

    protected override void OnTakeDamage()
    {
        _healthView.Show((float)Value / MaxValue);
    }

    private void OnValidate()
    {
        if (_healthViewSource && !(_healthViewSource is IHealthView))
        {
            Debug.LogError(nameof(_healthViewSource) + "is not implement " + nameof(IHealthView));
            _healthViewSource = null;
        }
    }
}