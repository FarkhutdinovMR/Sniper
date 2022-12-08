using UnityEngine;

public class Ragdoll : MonoBehaviour, IRagdoll
{
    private Rigidbody[] _rigidbodies;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        Disable();
    }

    public void Enable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = false;
    }

    public void Disable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = true;
    }
}

public interface IRagdoll
{
    void Enable();
    void Disable();
}