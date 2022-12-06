using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputRouter : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _weaponSource;
    private IWeapon _weapon => (IWeapon)_weaponSource;

    public void OnShoot(CallbackContext context)
    {
        if (context.performed)
            _weapon.Shoot();
    }

    public void OnZoom(CallbackContext context)
    {
        if (context.performed)
            _weapon.Zoom();
    }

    private void OnValidate()
    {
        if (_weaponSource && !(_weaponSource is IWeapon))
        {
            Debug.LogError(nameof(_weaponSource) + "is not implement " + nameof(IWeapon));
            _weaponSource = null;
        }
    }
}