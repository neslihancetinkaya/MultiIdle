using UnityEngine;
using UnityEngine.InputSystem;
using Utils.RefValue;

public class ValueSetter : MonoBehaviour
{
    [SerializeField] private IntRef Reference;
    [SerializeField] private int IntValue;

    private void Awake()
    {
        Reference.Value = IntValue;
    }
}
