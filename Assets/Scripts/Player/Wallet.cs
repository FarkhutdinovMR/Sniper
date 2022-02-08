using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;

    public event Action<int> Changed;

    private void Start()
    {
        Changed?.Invoke(_money);
    }

    public void AddMoney(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _money += value;

        Changed?.Invoke(_money);
    }
}