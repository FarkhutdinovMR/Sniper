using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private RewardCalculate _rewardCalculate;

    public void Init(RewardCalculate scoreCalculate)
    {
        _rewardCalculate = scoreCalculate;
    }

    public void ApplyReward()
    {
        _rewardCalculate.SendReward(_money);
    }
}