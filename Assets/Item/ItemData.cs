using UnityEngine;
using System.Collections;

public class ItemData
{
    public string name { get; private set; }
    public ItemType type { get; private set; }
    public float healthPoints { get; private set; }
    public float powerPoints { get; private set; }
    public float reductionPoints { get; private set; }
    public float hastePoints { get; private set; }
    public float movementSpeedPoints { get; private set; }
    public EquipSlot slot { get; private set; }

    // Constructor for items that are not equipable
    public ItemData(string aName, ItemType aType, float hp, float damage, float reduction, float haste, float movementSpeed)
    {
        this.initItem(aName, aType, hp, damage, reduction, haste, movementSpeed);
        this.slot = EquipSlot.None;
    }

    // Constructor for items that are equipable, ie -  a slot is provided
    public ItemData(string aName, ItemType aType, float hp, float damage, float reduction, float haste, float movementSpeed, EquipSlot aSlot)
    {
        this.initItem(aName, aType, hp, damage, reduction, haste, movementSpeed);
        this.slot = aSlot;
    }

    private void initItem(string aName, ItemType aType, float hp, float damage, float reduction, float haste, float movementSpeed)
    {
        this.name = aName;
        this.type = aType;
        this.healthPoints = hp;
        this.powerPoints = damage;
        this.reductionPoints = reduction;
        this.hastePoints = haste;
        this.movementSpeedPoints = movementSpeed;
    }
}
