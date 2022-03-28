using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName  = "Dusk/IntAttribute")]
    public class IntAttribute : Attribute
    {
        public int Value;

        private void OnEnable()
        {
            Value = 0;
        }
    }
}
