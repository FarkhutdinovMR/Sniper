using BehaviorDesigner.Runtime;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private MonoBehaviour _ragdollSource;
    private IRagdoll _ragdoll => (IRagdoll)_ragdollSource;

    [SerializeField] private Animator _animator;
    [SerializeField] private BehaviorTree _behaviorTree;
    [SerializeField] private Transform _weapon;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private MonoBehaviour _weaponPhysicSource;
    private IPhysic _weaponPhysic => (IPhysic)_weaponPhysicSource;

    protected override void Die()
    {
        _ragdoll.Enable();
        _animator.enabled = false;
        _behaviorTree.DisableBehavior();
        _characterController.enabled = false;
        _weapon.parent = null;
        _weaponPhysic.Enable();
    }

    private void OnValidate()
    {
        if (_ragdollSource && !(_ragdollSource is IRagdoll))
        {
            Debug.LogError(nameof(_ragdollSource) + "is not implement " + nameof(IRagdoll));
            _ragdollSource = null;
        }

        if (_weaponPhysicSource && !(_weaponPhysicSource is IPhysic))
        {
            Debug.LogError(nameof(_weaponPhysicSource) + "is not implement " + nameof(IPhysic));
            _weaponPhysicSource = null;
        }
    }
}