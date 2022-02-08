using UnityEngine;

public class RewardCalculate : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    public void SendReward(int money)
    {
        _wallet.AddMoney(money);
    }
}