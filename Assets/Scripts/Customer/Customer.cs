using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Utils.RefValue;

public class Customer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private IntRef Money;

    private int _baseMoney = 1;
    private SelectBehavior selectBehavior = new SelectRandom();
    private int _level;
    private Shop _shop;    
    private FoodData _currentFood;
    private Transform _target;
    private bool _doMove;


    private void Start()
    {
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Shop>(out var shop);
        if(shop == _shop)
        {
            CustomerSpawner.Instance.Despawn(this.gameObject);
            Money.Value += _baseMoney * _level;
        }
    }

    private void OnDisable()
    {
        Reset();
    }

    private void Initialize()
    {  
        _shop = selectBehavior.SelectShop(this, BoardController.Instance.GetShops());
        _level = _shop.GetCurrentLevel();

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
        Agent.SetDestination(_target.position);
    }

    public int GetLevel()
    {
        return _level;
    }
}