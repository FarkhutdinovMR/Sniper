using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IReloader))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private UnityEvent _shooted;

    private IReloader _reloader;
    private IShooter _ammo;

    public event UnityAction Shooted
    {
        add => _shooted.AddListener(value);
        remove => _shooted.RemoveListener(value);
    }

    private void Awake()
    {
        _reloader = GetComponent<IReloader>();
    }

    private void OnEnable()
    {
        _reloader.Reloaded += OnReloaded;
    }

    private void OnDisable()
    {
        _reloader.Reloaded -= OnReloaded;
    }

    private void Start()
    {
        _reloader.Reload();
    }

    public void Shoot()
    {
        if (_ammo == null)
            return;

        _ammo.Shoot();
        _ammo = null;
        _shooted.Invoke();

        _reloader.Reload();
    }

    private void OnReloaded(IShooter ammo)
    {
        _ammo = ammo;
    }
}