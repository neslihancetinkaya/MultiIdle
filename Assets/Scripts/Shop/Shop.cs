using System;
using TMPro;
using UnityEngine;
using Utils.RefValue;

public class Shop : MonoBehaviour, IShop
{
    [SerializeField] private IntRef Money;
    [SerializeField] private FoodData foodData;
    [SerializeField] private LevelData levelData;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private GameObject UpgradeButton;

    private int _currentLevel;
    public static event Action<Shop> OnShopAdded;
    public static event Action<Shop> OnShopUpdated;
    public virtual void Initialize()
    {
        //set model
        _currentLevel = (1);
        UpdateShop();
        OnShopAdded?.Invoke(this);
    }

    public virtual void Upgrade()
    {
        if (Money.Value >= levelData.GetUpgradeCost(_currentLevel - 1))
        {
            //do buy 
            _currentLevel++;
            Debug.Log(_currentLevel);
            Money.Value -= levelData.GetUpgradeCost(_currentLevel - 1);
            UpdateShop();
        }
        else
        {
            Debug.Log("You don't have enough money!");
        }
    }

    private void UpdateShop()
    {
        SpriteRenderer.sprite = levelData.GetBuildingSprite(_currentLevel - 1);
        LevelText.text = ("Level " + _currentLevel.ToString());

        OnShopUpdated?.Invoke(this);
        if (_currentLevel < levelData.GetSpritesLength())
            return;

        //Turn of upgrade button interactable and text to MAX
        UpgradeButton.SetActive(false);
        return;
    }

    public FoodData GetFoodData() { 
        return foodData;
    }

    public int GetCurrentLevel()
    {
        return _currentLevel;
    }
}
