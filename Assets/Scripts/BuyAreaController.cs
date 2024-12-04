using UnityEngine;
using Utils.RefValue;

public class BuyAreaController : MonoBehaviour
{
    [SerializeField] private GameObject ChoosePanel;
    [SerializeField] private IntRef Money;
    [SerializeField] private float AreaCost;

    //Close the Panel and set active the building menu
    public void OnBuyClick()
    {
        if(Money.Value >= AreaCost)
        {
            ChoosePanel.SetActive(true);
        }
    }
}


// should level be data based or should every level hold their own value?