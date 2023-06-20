using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public ItemObject[] possibleItems;
    public ItemObject[] items = new ItemObject[5];
    public Image[] uiImages = new Image[5];
    public Sprite uiEmptyItem;
    public Transform modelTransform;
    public float itemDeactivateTime = 10;
    public Animator anim;

    int maxItemInInventory = 5;

	private void Start()
	{
        UpdateUI();
    }

	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UseItem(4);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        int randomItemIndex = UnityEngine.Random.Range(0, possibleItems.Length);
        ItemObject randomItem = possibleItems[randomItemIndex];

        if (item)
        {
            //Adds 1 item to your inventory
            int itemCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = randomItem;
                    UpdateUI();
                    break;
                }
                itemCount++;
            }
            if (itemCount < maxItemInInventory)
            {
                //Destroys item we touched
                StartCoroutine(DeactivateItemTimer(item));
            }
        }
    }


    IEnumerator DeactivateItemTimer(Item item)
	{
        item.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        item.gameObject.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(itemDeactivateTime);
        item.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        item.gameObject.GetComponent<SphereCollider>().enabled = true;
    }


    void UseItem(int i)
    {
        if (items[i] == null)
            return;

        Instantiate(items[i].gamePrefab, transform.position, modelTransform.rotation);
        items[i] = null;
        UpdateUI();
        anim.SetTrigger("interact");
    }


    private void UpdateUI()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                uiImages[i].sprite = items[i].image;
            }
            else
            {
                uiImages[i].sprite = uiEmptyItem;
            }
        }
    }
}
