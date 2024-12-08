using TMPro;
using UnityEngine;
using Utils.RefValue;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private IntRef Money;
    [SerializeField] private IntRef ClientMoney;
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] private TextMeshProUGUI ClientMoneyText;

    public void UpdateText()
    {
        MoneyText.text = "Money: " + Money.Value.ToString();
        ClientMoneyText.text = "Client Money: " + ClientMoney.Value.ToString();
    }
}
