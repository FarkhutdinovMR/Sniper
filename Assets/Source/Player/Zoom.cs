using Cinemachine;
using UnityEngine;

public class Zoom : MonoBehaviour, IZoom
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CinemachineVirtualCamera _idleCamera;
    [SerializeField] private CinemachineVirtualCamera _zoomCamera;
    [SerializeField] private GameObject _scope;

    private CinemachinePOV _idleCinemachinePOV;
    private CinemachinePOV _zoomCinemachinePOV;

    public bool IsActive => _scope.activeSelf;

    private void Start()
    {
        CinemachineComponentBase componentBase = _idleCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim);
        _idleCinemachinePOV = componentBase as CinemachinePOV;
        componentBase = _zoomCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim);
        _zoomCinemachinePOV = componentBase as CinemachinePOV;
    }

    public void In()
    {
        _animator.Play("Idle");
        _idleCinemachinePOV.m_VerticalAxis.Value = _zoomCinemachinePOV.m_VerticalAxis.Value;
        _idleCinemachinePOV.m_HorizontalAxis.Value = _zoomCinemachinePOV.m_HorizontalAxis.Value;
        _scope.SetActive(false);
    }

    public void Out()
    {
        _animator.Play("Zoom");
        _zoomCinemachinePOV.m_VerticalAxis.Value = _idleCinemachinePOV.m_VerticalAxis.Value;
        _zoomCinemachinePOV.m_HorizontalAxis.Value = _idleCinemachinePOV.m_HorizontalAxis.Value;
        _scope.SetActive(true);
    }
}

public interface IZoom
{
    bool IsActive { get; }
    void In();
    void Out();
}