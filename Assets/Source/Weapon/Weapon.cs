using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float _rateOfFire;
    [field: SerializeField] public uint Damage { get; private set; }

    private bool _canShoot = true;

    public bool CanShoot => _canShoot;

    public void Shoot()
    {
        if (CanShoot == false)
            throw new InvalidOperationException();

        OnShoot();

        _canShoot = false;
        StartCoroutine(Wait(_rateOfFire, () => _canShoot = true));
    }

    protected virtual void OnShoot() { }

    private IEnumerator Wait(float time, Action onSuccessCallback)
    {
        yield return new WaitForSeconds(time);
        onSuccessCallback?.Invoke();
    }
}