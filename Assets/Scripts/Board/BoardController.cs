using System.Collections.Generic;
using UnityEngine;
using Utils.Event;

// Singleton
public class BoardController : MonoBehaviour
{
    public static BoardController Instance { get; private set; }
    [SerializeField] private GameEvent FirstShopAdded;

    private List<Shop> _shops; // add sushi taco and pizza data
    private int _maxLevel;
    private bool _isFirst = true;

    private void OnEnable()
    {
        _maxLevel = 0;
        Shop.OnShopAdded += AddShopToList;
    }
    private void Awake()
    {
        Instance = this;
        _shops = new List<Shop>();
    }

    private void OnDisable()
    {
        Shop.OnShopAdded -= AddShopToList;
    }

    private void AddShopToList(Shop shop)
    {
        if (_isFirst)
        {
            _isFirst = false;
            FirstShopAdded.Raise();
        }
        if (_shops.Contains(shop))
        {
            _shops.Remove(shop);
        }
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
}
