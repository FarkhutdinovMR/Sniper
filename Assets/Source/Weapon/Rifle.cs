using Cinemachine;
using UnityEngine;

public class Rifle : Weapon, ISniperWeapon
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private MonoBehaviour _zoomSource;
    private IZoom _zoom => (IZoom)_zoomSource;

    [SerializeField] private CinemachineImpulseSource _impulseSource;
    [SerializeField] private Transform _camera;
    [SerializeField] private Alarm _alarm;

    protected override void OnShoot()
    {
        if (_zoom.IsActive == false)
            return;

        Bullet bullet = Instantiate(_bulletTemplate);
        bullet.Init(_camera);
        _impulseSource.GenerateImpulse();

        if (_alarm.IsActive == false)
            _alarm.RaiseAlarm();
    }

    public void Zoom()
    {
        if (_zoom.IsActive)
            _zoom.Out();
        else
            _zoom.In();
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