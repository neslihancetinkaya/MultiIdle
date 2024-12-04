using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<Sprite> ShopSprites;
    [SerializeField] private List<int> UpgradeCosts;

    private int currentLevel;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    public Sprite GetBuildingSprite(int index)
    {
        return ShopSprites[index];
    }

    public int GetUpgradeCost(int index)
    {
        return UpgradeCosts[index];
    }

    public int GetSpritesLength()
    {
        return ShopSprites.Count;
    }    
}
