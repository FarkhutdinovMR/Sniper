using System.Collections;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private AnimationCurve _verticalCurve;
    [SerializeField] private float _speed;
    [SerializeField] private float _scale;

    Coroutine coroutine;

    private void OnEnable()
    {
        _weapon.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        _weapon.Shooted -= OnShooted;
    }

    private void OnShooted()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        float runningTime = 0;

        while (runningTime < 1)
        {
            runningTime += Time.deltaTime * _speed;
            float vertical = _verticalCurve.Evaluate(runningTime);
            transform.eulerAngles += Vector3.left * vertical * _scale;

            yield return null;
        }

        coroutine = null;
    }
}