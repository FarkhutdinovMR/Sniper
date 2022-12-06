using UnityEngine;

public class WeaponSmoothRotater : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _dampTime;

    private void Start()
    {
        transform.parent = null;
    }

    private void LateUpdate()
    {
        transform.position = _target.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation, _dampTime * Time.deltaTime);
    }
}