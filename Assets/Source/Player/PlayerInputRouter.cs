using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputRouter : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _weaponSource;
    private ISniperWeapon _weapon => (ISniperWeapon)_weaponSource;

    public void OnShoot(CallbackContext context)
    {
        if (context.performed && _weapon.CanShoot)
            _weapon.Shoot();
    }

    public void OnZoom(CallbackContext context)
    {
        if (context.performed)
            _weapon.Zoom();
    }

    private void OnValidate()
    {
        if (_weaponSource && !(_weaponSource is ISniperWeapon))
        {
            Debug.LogError(nameof(_weaponSource) + "is not implement " + nameof(ISniperWeapon));
            _weaponSource = null;
        }
    }
}