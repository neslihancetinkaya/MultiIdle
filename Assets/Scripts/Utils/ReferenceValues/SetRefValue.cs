using UnityEngine;
using Utils.RefValue;

public class SetRefValue : MonoBehaviour
{
    [SerializeField] private IntRef Ref;
    [SerializeField] private int value;
    private void Awake()
    {
        Ref.Value = value;
    }
}
