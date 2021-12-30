using UnityEngine;
using UnityEngine.Events;

public abstract class Objective : MonoBehaviour
{
    private Status _status;
    
    public event UnityAction Completed;
    public event UnityAction Failed;

    private enum Status
    {
        Active,
        Completed,
        Failed
    }

    protected void Complete()
    {
        if (_status != Status.Active)
            return;

        _status = Status.Completed;

        Completed?.Invoke();
    }

    protected void Fail()
    {
        if (_status != Status.Active)
            return;

        _status = Status.Failed;

        Failed?.Invoke();
    }
}