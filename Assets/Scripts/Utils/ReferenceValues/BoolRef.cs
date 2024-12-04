using UnityEngine;
using Utils.Event;

namespace Utils.RefValue
{
    [CreateAssetMenu]
    public class BoolRef : ScriptableObject
    {
        [SerializeField] private GameEvent CheckList;
        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                CheckList.Raise();
            }
        }

        private bool _value; 
    }
}