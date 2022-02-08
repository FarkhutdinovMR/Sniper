using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class MoneyPresenter : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TMP_Text _money;

    private void Awake()
    {
        _money = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _wallet.Changed -= OnChanged;
    }

    private void OnChanged(int money)
    {
        _money.SetText(money.ToString());
    }
}