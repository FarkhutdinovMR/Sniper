using UnityEngine;

[RequireComponent (typeof(Collider), typeof(Rigidbody))]
public class WeaponPhysic : MonoBehaviour, IPhysic
{
    private Collider _collider;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Disable()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    public void Enable()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }
}

public interface IPhysic
{
    void Enable();
    void Disable();
}