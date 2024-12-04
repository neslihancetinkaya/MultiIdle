using System.Collections.Generic;
using UnityEngine;

public class SelectRandom : SelectBehavior
{
    public Shop SelectShop(Customer customer, List<Shop> shops)
    {
        shops = BoardController.Instance.GetShops();
        return shops[Random.Range(0, shops.Count)];
    }
}
