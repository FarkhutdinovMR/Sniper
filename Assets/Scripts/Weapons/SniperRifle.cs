using System.Collections;
using UnityEngine;

public class SniperRifle : MonoBehaviour, IShooter
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private float _delayBetweenShoot;
    [SerializeField] private float _reloadDuration;

    private int _currentAmmo;
    private Coroutine _reload;

    private void Start()
    {
        _currentAmmo = _maxAmmo;
    }

    public void Shoot()
    {
        if (_reload != null)
            return;

        Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
        _currentAmmo--;

        if (_currentAmmo <= 0)
            _reload = StartCoroutine(Reload());
        else
            _reload = StartCoroutine(FastReload());
    }

    private IEnumerator FastReload()
    {
        yield return new WaitForSeconds(_delayBetweenShoot);

        _reload = null;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadDuration);

        _currentAmmo = _maxAmmo;

        _reload = null;
    }
}