using System;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool IsActive;

    public void RaiseAlarm()
    {
        if (IsActive)
            throw new InvalidOperationException();

        IsActive = true;
    }
}