using UnityEngine;

public class FoodButton : MonoBehaviour
{
    [SerializeField] private Factory factory;
    [SerializeField] private UIController myUIController;

    private Transform spawnTransform;
    public void OnButtonClick()
    {
        spawnTransform = myUIController.transform;
        myUIController.DeactivateCanvas();
        factory.CreateShop(spawnTransform.position);
    }
}
