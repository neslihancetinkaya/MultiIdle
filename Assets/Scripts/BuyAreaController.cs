using TMPro;
using UnityEngine;
using Utils.RefValue;

public class BuyAreaController : MonoBehaviour
{
    [SerializeField] private GameObject ChoosePanel;
    [SerializeField] private IntRef Money;
    [SerializeField] private float AreaCost;
    [SerializeField] private TextMeshProUGUI ValueText;

    private void Awake()
    {
        // TODO: Use FloatRef for AreaCost, increase it every time an area purchased
        ValueText.text = AreaCost.ToString();
    }

    public void OnBuyClick()
    {
        if(Money.Value >= AreaCost)
        {
            ChoosePanel.SetActive(true);
        }
    }
}