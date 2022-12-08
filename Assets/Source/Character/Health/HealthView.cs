using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IHealthView
{
    [SerializeField] private Slider _valueSlider;

    public void Show(float value)
    {
        _valueSlider.value = value;
    }
}

public interface IHealthView
{
    void Show(float value);
}