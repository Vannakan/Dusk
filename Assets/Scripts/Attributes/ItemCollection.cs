using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Dusk/ItemCollection")]
    public class ItemCollection : ScriptableObject
    {
        public List<Item> All;

        private void OnEnable()
        {
            All = new List<Item>();
        }
    }
}
