using Cinemachine;
using UnityEngine;

public class Zoom : MonoBehaviour, IZoom
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CinemachineVirtualCamera _idleCamera;
    [SerializeField] private CinemachineVirtualCamera _zoomCamera;

    private CinemachinePOV _idleCinemachinePOV;
    private CinemachinePOV _zoomCinemachinePOV;

    private bool _isZoom;

    private void Start()
    {
        CinemachineComponentBase componentBase = _idleCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim);
        _idleCinemachinePOV = componentBase as CinemachinePOV;
        componentBase = _zoomCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim);
        _zoomCinemachinePOV = componentBase as CinemachinePOV;
    }

    public void DoZoom()
    {
        if (_isZoom)
        {
            _isZoom = false;
            _animator.Play("Idle");
            _idleCinemachinePOV.m_VerticalAxis.Value = _zoomCinemachinePOV.m_VerticalAxis.Value;
            _idleCinemachinePOV.m_HorizontalAxis.Value = _zoomCinemachinePOV.m_HorizontalAxis.Value;
        }
        else
        {
            _isZoom = true;
            _animator.Play("Zoom");
            _zoomCinemachinePOV.m_VerticalAxis.Value = _idleCinemachinePOV.m_VerticalAxis.Value;
            _zoomCinemachinePOV.m_HorizontalAxis.Value = _idleCinemachinePOV.m_HorizontalAxis.Value;
        }
    }
}

public interface IZoom
{
    void DoZoom();
}