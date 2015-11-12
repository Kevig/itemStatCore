using UnityEngine;
using System.Collections;

public class Item
{
    public string name { get; private set; }
    public int id { get; private set; }

    public ItemIcon icon { get; private set; }
    public ItemType type { get; private set; }
    public ItemModel model { get; private set; }
    public EquipSlot slot;

    // Initialise item, pre-condition - Item exists in itemList
    public Item(int anId)
    {
        ItemData data = ItemList.getData(anId);
        this.id = anId;
        this.name = data.name;
        this.type = data.type;
        this.slot = data.slot;
    }
}
