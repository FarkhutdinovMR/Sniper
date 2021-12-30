using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public abstract class ProgressBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected void OnValueChanged(int value, int maxValue)
    {
        if (value > maxValue)
            throw new ArgumentOutOfRangeException(nameof(maxValue));

        _slider.value = (float)value / maxValue;
    }

    protected void OnValueChanged(float value, float maxValue)
    {
        if (value > maxValue)
            throw new ArgumentOutOfRangeException(nameof(maxValue));

        _slider.value = (float)value / maxValue;
    }
}