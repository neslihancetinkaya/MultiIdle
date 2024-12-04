using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering;

public class Customer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float Speed;

    private SelectBehavior selectBehavior = new SelectShopByLevel();

    private int _level;
    private Shop _shop;    
    private FoodData _currentFood;
    private Transform _target;
    private bool _doMove;

    private void OnEnable()
    {
        Initialize();
    }
    private void Update()
    {
        if (!_doMove)
            return;
        Move();
    }

    private void OnDisable()
    {
        Reset();
    }

    private void Initialize()
    {        
        _level = Random.Range(0, BoardController.Instance.GetMaxLevel()) + 1; // +1 used to adjust value

        _shop = selectBehavior.SelectShop(this, BoardController.Instance.GetShops());
        _currentFood = _shop.GetFoodData();
        spriteRenderer.sprite = _currentFood.GetSprite();
        _doMove = true;
        _target = _shop.transform;
    }

    private void Reset()
    {
        _doMove = false;
        transform.position = Vector3.zero;
        _shop = null;
        _currentFood = null;
        spriteRenderer.sprite = null;
        _target = null;
    }

    private void Move()
    {
        //Change to: move to x pos first then move to y
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Speed);
    }

    public int GetLevel()
    {
        return _level;
    }
}