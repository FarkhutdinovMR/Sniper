using Cinemachine;
using UnityEngine;

public class Rifle : MonoBehaviour, IWeapon
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private MonoBehaviour _zoomSource;
    private IZoom _zoom => (IZoom)_zoomSource;

    [SerializeField] CinemachineImpulseSource _impulseSource;

    public void Shoot()
    {
        Instantiate(_bulletTemplate);
        _impulseSource.GenerateImpulse();
    }

    public void Zoom()
    {
        _zoom.DoZoom();
    }

    private void OnValidate()
    {
        if (_zoomSource && !(_zoomSource is IZoom))
        {
            Debug.LogError(nameof(_zoomSource) + "is not implement " + nameof(IZoom));
            _zoomSource = null;
        }
    }
}

public interface IWeapon
{
    void Shoot();
    void Zoom();
}

public interface IBullet { }