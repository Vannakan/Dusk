using Assets;
using Assets.Scripts;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Dusk/Inventory")]
public class Inventory : ScriptableObject
{
    public IntAttribute Gold;

    public ItemCollection Items;

    public event EventHandler<Item> ItemAdded;

    public void AddItem(Item item)
    {
        if (item != null)
        {
            //All is dumb
            Items.All.Add(item);
            OnItemAdded(item);
       }
    }

    protected virtual void OnItemAdded(Item item)
    {
        ItemAdded?.Invoke(this, item);
    }
}
