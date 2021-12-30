using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _value;

    private const float MinValue = 0;
    private const string Dead = "Dead";

    public event Action Dies;
    public event Action<float, float> Changed;

    public bool isAlive => _value > 0;

    private void Start()
    {
        _value = _maxValue;
        Changed?.Invoke(_value, _maxValue);
    }

    public void TakeDamage(float damage)
    {
        if (isAlive == false)
            return;

        _value -= damage;

        _value = Mathf.Clamp(_value, MinValue, _maxValue);

        if (_value <= 0)
            Died();

        Changed?.Invoke(_value, _maxValue);
    }

    private void Died()
    {
        gameObject.layer = LayerMask.NameToLayer(Dead);
        Dies?.Invoke();
    }
}