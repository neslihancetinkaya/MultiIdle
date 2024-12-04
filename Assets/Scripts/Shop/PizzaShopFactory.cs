using UnityEngine;

public class PizzaShopFactory : Factory
{
    [SerializeField] private PizzaShop PizzaShopPrefab;
    public override IShop CreateShop(Vector3 position)
    {
        GameObject pizzaShopInstance = Instantiate(PizzaShopPrefab.gameObject, position, Quaternion.identity);
        PizzaShop newpizzaShop = pizzaShopInstance.GetComponent<PizzaShop>();

        newpizzaShop.Initialize();

        return newpizzaShop;
    }
}
