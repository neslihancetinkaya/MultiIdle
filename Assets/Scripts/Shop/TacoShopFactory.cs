using UnityEngine;

public class TacoShopFactory : Factory
{
    [SerializeField] private TacoShop TacoShopPrefab;
    public override IShop CreateShop(Vector3 position)
    {
        GameObject tacoShopInstance = Instantiate(TacoShopPrefab.gameObject, position, Quaternion.identity);
        TacoShop newTacoShop = tacoShopInstance.GetComponent<TacoShop>();

        newTacoShop.Initialize();

        return newTacoShop;
    }
}
