using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(View))]
public class Input : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Weapon _weapon;

    private View _overview;
    private InputAction _look;

    private const string Look = "Look";

    private void Start()
    {
        _overview = GetComponent<View>();
        _look = _playerInput.actions[Look];
    }

    private void Update()
    {
        _overview.Rotate(_look.ReadValue<Vector2>());
    }

    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
            _weapon.Shoot();
    }
}