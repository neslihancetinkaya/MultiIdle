using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    private const int POOL_SIZE = 10;

    [SerializeField] private float RepeatTime;
    [SerializeField] private GameObject CustomerPrefab;

    private float _nextTime;
    private Queue<GameObject> customerPool;
    private bool _canSpawn;

    private void Start()
    {
        customerPool = new Queue<GameObject>();

        for (int i = 0; i < POOL_SIZE; ++i) {
            GameObject customer = Instantiate(CustomerPrefab, Vector3.zero, Quaternion.identity);
            customer.SetActive(false);
            customerPool.Enqueue(customer);
        }
    }
    private void Update()
    {
        if (Time.time > _nextTime)
        {
            HandleSpawn();
            _nextTime = Time.time + RepeatTime;
        }
    }   

    private GameObject GetCustomerFromPool()
    {
        if (customerPool.Count > 0)
        {
            GameObject customer = customerPool.Dequeue();
            customer.SetActive(true);
            return customer;
        }

        return null;
    }

    private void ReturnCustomerToPool(GameObject customer)
    {
        customer.SetActive(false);
        customerPool.Enqueue(customer);
    }

    private IEnumerator DisableCustomerAfterDelay(GameObject customer, float delay) {
        yield return new WaitForSeconds(delay);
        ReturnCustomerToPool(customer);
    }

    private void HandleSpawn()
    {
        GameObject customer = GetCustomerFromPool();

        if (customer != null)
        {
            customer.transform.position = transform.position;
            customer.SetActive(true);

            StartCoroutine(DisableCustomerAfterDelay(customer, 5f));
        }
    }
    
    public void Despawn(GameObject customer)
    {
        ReturnCustomerToPool(customer);
    }

    public GameObject Spawn()
    {
        return GetCustomerFromPool();
    }
}
