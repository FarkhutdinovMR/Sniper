using System;
using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour, IShooter
{
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadDuration;

    private Coroutine _reload;
    private Arrow _currentArrow;

    public event Action Shooted;

    private void Start()
    {
        _reload = StartCoroutine(Reload());
    }

    public void Shoot()
    {
        if (_reload != null)
            return;

        _currentArrow.Shoot();

        _reload = StartCoroutine(Reload());

        Shooted?.Invoke();
    }

    private IEnumerator Reload()
    {
        _currentArrow = Instantiate(_arrow, startPoint.position, _shootPoint.rotation);
        _currentArrow.transform.parent = transform;

        float runningTime = 0;

        while (runningTime < _reloadDuration)
        {
            runningTime += Time.deltaTime;

            _currentArrow.transform.position = Vector3.Lerp(startPoint.position, _shootPoint.position, runningTime / _reloadDuration);

            yield return null;
        }

        _reload = null;
    }
}