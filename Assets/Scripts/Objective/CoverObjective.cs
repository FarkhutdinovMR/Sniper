using UnityEngine;

public class CoverObjective : Objective
{
    [SerializeField] private Character _character;
    [SerializeField] private Health _characterHealth;

    private void OnEnable()
    {
        _character.ReachedSafeArea += OnReachedSafeArea;
        _characterHealth.Dies += OnDies;
    }

    private void OnDisable()
    {
        _character.ReachedSafeArea -= OnReachedSafeArea;
        _characterHealth.Dies -= OnDies;
    }

    private void OnReachedSafeArea()
    {
        Complete();
    }

    private void OnDies()
    {
        Fail();
    }
}