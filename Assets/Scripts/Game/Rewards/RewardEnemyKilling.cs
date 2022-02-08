using UnityEngine;

[RequireComponent(typeof(Health))]
public class RewardEnemyKilling : Reward
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Dies += OnDies;
    }

    private void OnDisable()
    {
        _health.Dies -= OnDies;
    }

    private void OnDies()
    {
        ApplyReward();
    }
}