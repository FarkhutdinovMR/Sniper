using System;
using System.Collections;
using UnityEngine;

public class ClipReloader : MonoBehaviour, IReloader
{
    [SerializeField] private BulletShooter _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private float _delayBetweenShoot;
    [SerializeField] private float _reloadDuration;

    private int _currentAmmo;
    private Coroutine _reload;

    public event Action<IShooter> Reloaded;

    private void Start()
    {
        _currentAmmo = _maxAmmo;
    }

    public void Reload()
    {
        if (_reload != null)
            return;

        _currentAmmo--;

        if (_currentAmmo <= 0)
            _reload = StartCoroutine(LongReload());
        else
            _reload = StartCoroutine(FastReload());
    }

    private IEnumerator FastReload()
    {
        yield return new WaitForSeconds(_delayBetweenShoot);

        _reload = null;

        BulletShooter bullet = Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
        bullet.transform.parent = transform;

        Reloaded?.Invoke(bullet);
    }

    private IEnumerator LongReload()
    {
        yield return new WaitForSeconds(_reloadDuration);

        _currentAmmo = _maxAmmo;

        _reload = StartCoroutine(FastReload());
    }
}