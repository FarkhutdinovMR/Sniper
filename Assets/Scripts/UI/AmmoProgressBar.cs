using UnityEngine;

public class AmmoProgressBar : ProgressBar
{
    [SerializeField] private Bow _weapon;

    private void OnEnable()
    {
        //_weapon.BulletInClipChanged += OnValueChanged;
    }

    private void OnDisable()
    {
       // _weapon.BulletInClipChanged -= OnValueChanged;
    }
}