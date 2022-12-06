using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _impulseForce;

    private void Start()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.rigidbody != null)
                Push(hitInfo);
        }

        Destroy(gameObject);
    }

    private void Push(RaycastHit hitInfo)
    {
        Vector3 direction = (hitInfo.point - Camera.main.transform.position).normalized;
        hitInfo.rigidbody.AddForce(direction * _impulseForce, ForceMode.Impulse);
    }
}