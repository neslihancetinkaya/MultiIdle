using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public abstract IShop CreateShop(Vector3 position);
}
