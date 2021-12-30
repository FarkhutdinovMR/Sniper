using UnityEngine;

public class HealthProgressBar : ProgressBar
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Changed += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnValueChanged;
    }
}