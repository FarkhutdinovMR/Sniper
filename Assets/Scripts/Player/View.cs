using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private float _sensitive;
    [SerializeField] private Vector2 _horizontalRange;
    [SerializeField] private Vector2 _verticalRange;


    private Vector2 _currentRotate;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _currentRotate = transform.localEulerAngles;
    }

    public void Rotate(Vector2 direction)
    {
        _currentRotate += new Vector2(-direction.y * _sensitive, direction.x * _sensitive);
        _currentRotate = Clamp(_currentRotate);
        transform.eulerAngles = _currentRotate;
    }

    private Vector3 Clamp(Vector2 rotate)
    {
        return new Vector3(Mathf.Clamp(rotate.x, _verticalRange.x, _verticalRange.y), Mathf.Clamp(rotate.y, _horizontalRange.x, _horizontalRange.y), 0);
    }
}