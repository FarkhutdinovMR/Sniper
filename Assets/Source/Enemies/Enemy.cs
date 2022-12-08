using BehaviorDesigner.Runtime;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BehaviorTree _behaviorTree;

    private Rigidbody[] _rigidbodies;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    public void TakeDamage(uint damage)
    {
        EnableRagdoll();
        _behaviorTree.DisableBehavior();
    }
    private void EnableRagdoll()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = false;
        _animator.enabled = false;
    }

    public void DisableRagdoll()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = true;
    }

}