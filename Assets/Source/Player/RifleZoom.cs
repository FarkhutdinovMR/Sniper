using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RifleZoom : MonoBehaviour, IZoom
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float _defaultFOV;
    [SerializeField] private float _zoomFOV;
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private Image _scope;

    private bool _isActive;
    private Coroutine _coroutine;
    private Color _defaultColor;

    public bool IsActive => _isActive;

    private void Awake()
    {
        _defaultColor = _scope.color;
    }

    public void In()
    {
        _isActive = true;
        _scope.gameObject.SetActive(true);
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(DoZoom(_zoomFOV, () => _coroutine = null));
    }

    public void Out()
    {
        _isActive = false;
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(DoZoom(_defaultFOV, () =>
        {
            _scope.gameObject.SetActive(false);
            _coroutine = null;
        }));
    }

    private IEnumerator DoZoom(float fov, Action onEndCallback = null)
    {
        float length = _defaultFOV - _zoomFOV;
        while (Mathf.Approximately(_camera.m_Lens.FieldOfView, fov) == false)
        {
            _camera.m_Lens.FieldOfView = Mathf.MoveTowards(_camera.m_Lens.FieldOfView, fov, _transitionSpeed * Time.deltaTime);
            _scope.color = Color.Lerp(_defaultColor, Color.clear, (_camera.m_Lens.FieldOfView - _zoomFOV) / length);
            yield return null;
        }

        onEndCallback?.Invoke();
    }
}