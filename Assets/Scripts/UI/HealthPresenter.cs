using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private ProgressBar _progressBar;

    private void OnEnable()
    {
        _health.Changed += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnValueChanged;
    }

    private void OnValueChanged(float value, float maxValue)
    {
        _progressBar.SetValue(value, maxValue);
    }
}