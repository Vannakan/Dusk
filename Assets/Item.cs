using Assets.Scripts;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Dusk/Item")]
    public class Item : ScriptableObject
    {
        //passives
        //attributes
        public string Name;
        public int Health = 1;
        public int Damage = 1;
        public Sprite Sprite;
        //Sprite?
    }
}
