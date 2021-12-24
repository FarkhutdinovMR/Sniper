using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            Destroy(enemy.gameObject);

        Destroy(gameObject);
    }
}