using UnityEngine;
using System.Collections;

public class Slot
{
    public bool isEmpty { get; private set; }
    public Item item { get; private set; }

    public Slot()
    {
        this.isEmpty = true;
        this.item = null;
    }

    public Slot(Item anItem)
    {
        this.add(anItem);
    }

    public void add(Item anItem)
    {
        this.isEmpty = false;
        this.item = anItem;
    }

    public void remove()
    {
        this.isEmpty = true;
        this.item = new Item(-1);
    }
}
