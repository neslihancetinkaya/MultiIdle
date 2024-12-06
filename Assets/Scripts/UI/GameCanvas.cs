using TMPro;
using UnityEngine;
using Utils.RefValue;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private IntRef Money;
    [SerializeField] private TextMeshProUGUI MoneyText;

    public void UpdateText()
    {
        MoneyText.text = "Money: " + Money.Value.ToString();
    }
}
