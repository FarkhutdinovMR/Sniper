using System;
using System.Collections;
using UnityEngine;

public class BowReloader : MonoBehaviour, IReloader
{
    [SerializeField] private ArrowShooter _arrow;
    [SerializeField] private Transform _reloadPoint;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadDuration;

    public event Action<IShooter> Reloaded;

    private Coroutine _reload;

    public void Reload()
    {
        if (_reload != null)
            return;

        _reload = StartCoroutine(StartReload());
    }

    private IEnumerator StartReload()
    {
        ArrowShooter arrow = Instantiate(_arrow, _reloadPoint.position, _shootPoint.rotation);
        arrow.transform.parent = transform;

        float runningTime = 0;

        while (runningTime < _reloadDuration)
        {
            runningTime += Time.deltaTime;

            arrow.transform.position = Vector3.Lerp(_reloadPoint.position, _shootPoint.position, runningTime / _reloadDuration);

            yield return null;
        }

        _reload = null;

        Reloaded?.Invoke(arrow);
    }
}