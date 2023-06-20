using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_START;
    public float Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMNS;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }
    private void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        //for (int i = 0; i < inventory.container.Count; i++)
        //{

        //    var obj = Instantiate(inventory.container[i]._item.prefab, Vector3.zero, Quaternion.identity, transform);
        //    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        //    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i]._amount.ToString("n0");
        //    itemsDisplayed.Add(inventory.container[i], obj);

        //}
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMNS)), 0f);
    }

    public void UpdateDisplay()
    {
        //for (int i = 0; i < inventory.container.Count; i++)
        //{

        //    if (itemsDisplayed.ContainsKey(inventory.container[i]))
        //    {
        //        itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i]._amount.ToString("n0");
        //    }
        //    else
        //    {
        //        var obj = Instantiate(inventory.container[i]._item.prefab, Vector3.zero, Quaternion.identity, transform);
        //        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        //        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i]._amount.ToString("n0");
        //        itemsDisplayed.Add(inventory.container[i], obj);
        //    }
        //}
    }
}
