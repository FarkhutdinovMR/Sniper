using UnityEngine;

public class RewardLevelCompletion : Reward
{
    [SerializeField] private Objective _objective;

    private void OnEnable()
    {
        _objective.Completed += OnCompleted;
    }

    private void OnDisable()
    {
        _objective.Completed -= OnCompleted;
    }

    private void OnCompleted()
    {
        ApplyReward();
    }
}