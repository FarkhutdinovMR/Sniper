using UnityEngine;

public class RewardDestory : Reward
{
    private void OnTriggerEnter(Collider other)
    {
        ApplyReward();
    }
}