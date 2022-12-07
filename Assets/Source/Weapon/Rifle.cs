using Cinemachine;
using UnityEngine;

public class Rifle : MonoBehaviour, IWeapon
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private MonoBehaviour _zoomSource;
    private IZoom _zoom => (IZoom)_zoomSource;

    [SerializeField] private CinemachineImpulseSource _impulseSource;
    [SerializeField] private Transform _camera;

    public void Shoot()
    {
        Bullet bullet = Instantiate(_bulletTemplate);
        bullet.Init(_camera);
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