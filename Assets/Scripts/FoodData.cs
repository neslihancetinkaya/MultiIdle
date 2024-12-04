using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoodData : ScriptableObject
{
    [SerializeField] private Sprite FoodSprite;   

    public Sprite GetSprite()
    {
        return FoodSprite;
    }
}
