using UnityEngine;

public class SushiShopFactory : Factory
{
    [SerializeField] private SushiShop SushiShopPrefab;
    public override IShop CreateShop(Vector3 position)
    {
        GameObject sushiShopInstance = Instantiate(SushiShopPrefab.gameObject, position, Quaternion.identity);
        SushiShop newSushiShop = sushiShopInstance.GetComponent<SushiShop>();

        newSushiShop.Initialize();

        return newSushiShop;
    }
}
