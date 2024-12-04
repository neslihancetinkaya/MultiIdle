using System.Collections.Generic;
using UnityEngine;

// Singleton
public class BoardController : MonoBehaviour
{
    public static BoardController Instance { get; private set; }

    private List<Shop> _shops; // add sushi taco and pizza data
    private int _maxLevel;

    private void OnEnable()
    {
        _maxLevel = 0;
        Shop.OnShopAdded += AddShopToList;
        Shop.OnShopUpdated += GetMax;
    }
    private void Awake()
    {
        Instance = this;
        _shops = new List<Shop>();
    }

    private void OnDisable()
    {
        Shop.OnShopAdded -= AddShopToList;
        Shop.OnShopUpdated -= GetMax;
    }

    private void AddShopToList(Shop shop)
    {
        _shops.Add(shop);
    }
    
    private void GetMax(Shop shop)
    {
        if (shop.GetCurrentLevel() > _maxLevel)
            _maxLevel = shop.GetCurrentLevel();
    }

    //we can do the operation here and send a random shop as target and the sprite data?
    public List<Shop> GetShops()
    {
        return _shops;
    }

    public int GetMaxLevel()
    {
        return _maxLevel;
    }
}
