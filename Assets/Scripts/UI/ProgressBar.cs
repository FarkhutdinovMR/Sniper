using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetValue(float value, float maxValue)
    {
        if (value > maxValue)
            throw new ArgumentOutOfRangeException(nameof(maxValue));

        _slider.value = value / maxValue;
    }
}