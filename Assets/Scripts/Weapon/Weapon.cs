using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;

    public void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
    }
}