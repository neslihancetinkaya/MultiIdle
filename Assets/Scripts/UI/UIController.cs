using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Model;

    public void DeactivateCanvas()
    {
        Canvas.SetActive(false);
    }

    public void DeactivateModel()
    {
        Model.SetActive(false);
    }
}
