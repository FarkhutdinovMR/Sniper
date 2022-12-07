using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _angularSpeed = 5f;

    private CharacterController _characterController;

    public float CurrentSpeed => _characterController.velocity.magnitude;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 delta)
    {
        var movement = new Vector3(delta.x, 0f, delta.y);
        movement *= _moveSpeed;
        _characterController.SimpleMove(movement);
        Rotate(delta);
    }

    private void Rotate(Vector2 delta)
    {
        if (delta == Vector2.zero)
            return;

        Quaternion rotate = Quaternion.LookRotation(new Vector3(delta.x, 0f, delta.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, _angularSpeed * Time.deltaTime);
    }
}