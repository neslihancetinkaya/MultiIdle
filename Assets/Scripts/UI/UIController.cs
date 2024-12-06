using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    public void DeactivateCanvas()
    {
        Canvas.SetActive(false);
    }
}
