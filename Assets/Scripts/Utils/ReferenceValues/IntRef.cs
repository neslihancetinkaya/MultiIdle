using UnityEngine;

namespace Utils.RefValue
{
    [CreateAssetMenu]
    public class IntRef : ScriptableObject
    {
        private int _value;

        public delegate void ValueChanged();
        public event ValueChanged OnValueChanged;

        public void ValueHasChanged()
        {
            OnValueChanged?.Invoke();
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueHasChanged();
            }
        }
    }
}