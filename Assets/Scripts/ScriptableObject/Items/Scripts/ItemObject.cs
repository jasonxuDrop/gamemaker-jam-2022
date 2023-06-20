using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Attack,
    Explosion,
    Health,

    Random
}

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Item")]
public class ItemObject : ScriptableObject
{
    public Sprite image;
    public GameObject gamePrefab;
    public ItemType type;

}
