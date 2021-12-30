using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        transform.LookAt(_camera.transform);
    }
}