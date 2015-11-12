using UnityEngine;
using System.Collections.Generic;

public static class ItemList
{
    public static Dictionary<int, ItemData> itemList { get; private set; }

    static ItemList()
    {
        // Items format - Name, Type, stats -> health, power, reduction, haste, moveSpeed, slot if applicable

        itemList = new Dictionary<int, ItemData>();

        itemList.Add(-1, new ItemData("empty",           ItemType.Equipment, 0f, 0f, 0f, 0f, 0f));
        itemList.Add(0,  new ItemData("baseStats",       ItemType.Equipment, 100f, 50f, 20f, 1f, 1f,     EquipSlot.Base));
        itemList.Add(1,  new ItemData("testHelm",        ItemType.Equipment, 10f, 5f, 2f, 0.1f, 0.1f,    EquipSlot.Head));
        itemList.Add(2,  new ItemData("testShoulders",   ItemType.Equipment, 10f, 5f, 2f, 0.1f, 0.1f,    EquipSlot.Shoulders));
        itemList.Add(3,  new ItemData("testChest",       ItemType.Equipment, 10f, 5f, 2f, 0.1f, 0.1f,    EquipSlot.Chest));
        itemList.Add(4,  new ItemData("testLegs",        ItemType.Equipment, 10f, 5f, 2f, 0.1f, 0.1f,    EquipSlot.Legs));
        itemList.Add(5,  new ItemData("testGloves",      ItemType.Equipment, 10f, 5f, 2f, 0.1f, 0.1f,    EquipSlot.Hands));
        itemList.Add(6,  new ItemData("testBoots",       ItemType.Equipment, 10f, 5f, 2f, 0.1f, 0.1f,    EquipSlot.Boots));

    }

    // Returns true if an item with a given id exists
    public static bool itemExists(int anId)
    {
        if(itemList.ContainsKey(anId))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Returns the itemData object associated with anId
    public static ItemData getData(int anId)
    {
        return itemList[anId];
    }
}
