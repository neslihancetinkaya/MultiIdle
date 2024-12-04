using System.Collections.Generic;
using UnityEngine;

public class SelectShopByLevel : SelectBehavior
{
    private List<Shop> _sameLevelShops;
    public Shop SelectShop(Customer customer, List<Shop> shops)
    {
        _sameLevelShops = new List<Shop>();

        shops = BoardController.Instance.GetShops();
        foreach (var shop in shops)
        {
            if (shop.GetCurrentLevel() == customer.GetLevel())
            {
                _sameLevelShops.Add(shop);
            }
        }

        return _sameLevelShops[Random.Range(0, _sameLevelShops.Count)];
    }
}
