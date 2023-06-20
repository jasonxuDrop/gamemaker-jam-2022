using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public InventorySlot[] container = new InventorySlot[5];
    public void AddItem(ItemObject item)
    {
        for (int i = 0; i < container.Length; i++)
        {
            Debug.Log("hello what are you doing????");
            if (container[i] == null)
			{
                container[i] = new InventorySlot(item);
            }
            else
			{

            }
        }
    }
}


[System.Serializable]
public class InventorySlot
{
    public ItemObject _item;

    public InventorySlot(ItemObject item)
    {
        _item = item;
    }
}