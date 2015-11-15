// KEEP IT SIMPLE STUPID
using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public Health health;
    public Power power;
    public Reduction reduction;
    public Haste haste;
    public MovementSpeed movementSpeed;

    public Slot baseStats;
    public Slot head;
    public Slot shoulder;
    public Slot chest;
    public Slot legs;
    public Slot hands;
    public Slot boots;
    public Slot mainHand;
    public Slot offHand;

    // Event for stats change
    public delegate void statsUpdate(Character aCharacter);
    public static event statsUpdate OnStatsUpdate;

    // Events for item change
    public delegate void itemUpdate(Character aCharacter);
    public static event itemUpdate OnChangeItem;

    // Test variables
    public float maxHealth;
    public float currentHealth;
    public float powerValue;
    public float reductionValue;
    public float hasteValue;
    public float moveSpeedValue;

    public string headSlot;
    public string shoulderSlot;
    public string chestSlot;
    public string legsSlot;
    public string handsSlot;
    public string bootsSlot;
    public string mainHandSlot;
    public string offhandSlot;

    void Awake()
    {

    }

    // Object initialization
    void Start()
    {
        // Initialise equipment slots to empty
        this.baseStats = new Slot(new Item(0));
        this.head = new Slot(new Item(-1));
        this.shoulder = new Slot(new Item(-1));
        this.chest = new Slot(new Item(-1));
        this.legs = new Slot(new Item(-1));
        this.hands = new Slot(new Item(-1));
        this.boots = new Slot(new Item(-1));
        this.mainHand = new Slot(new Item(-1));
        this.offHand = new Slot(new Item(-1));

        // Initialise Character Stats
        this.health = new Health(0f);
        this.power = new Power(0f);
        this.reduction = new Reduction(0f);
        this.haste = new Haste(0f);
        this.movementSpeed = new MovementSpeed(0f);

        // Calculate character stats from base values + item values
        this.updateStats();

        // Initialise current health to max
        this.health.value = this.health.max;

        // Update unity editor display for debugging purposes
        this.updateValuesText();

        // Update unity editor equipment slot item names display
        this.updateEquippedDisplay();
    }

    // Update all stat values - Testing purposes only
    private void updateStats()
    {
        this.health.max = this.getMaxHpValue();
        this.power.value = this.getPowerValue();
        this.reduction.value = this.getReductionValue();
        this.haste.value = this.getHasteValue();
        this.movementSpeed.value = this.getMovementSpeedValue();

        if(this.health.value > this.health.max)
        {
            this.health.value = this.health.max;
        }

        OnStatsUpdate(this);
        this.updateValuesText();
    }

    private void updateValuesText()
    {
        this.currentHealth = this.health.value;
        this.maxHealth = this.health.max;
        this.powerValue = this.power.value;
        this.reductionValue = this.reduction.value;
        this.hasteValue = this.haste.value;
        this.moveSpeedValue = this.movementSpeed.value;
    }

    private float getMaxHpValue()
    {
        float value = ItemList.getData(this.baseStats.item.id).healthPoints +
                      ItemList.getData(this.head.item.id).healthPoints +
                      ItemList.getData(this.shoulder.item.id).healthPoints +
                      ItemList.getData(this.chest.item.id).healthPoints +
                      ItemList.getData(this.legs.item.id).healthPoints +
                      ItemList.getData(this.hands.item.id).healthPoints +
                      ItemList.getData(this.boots.item.id).healthPoints +
                      ItemList.getData(this.mainHand.item.id).healthPoints +
                      ItemList.getData(this.offHand.item.id).healthPoints;

        return value;
    }

    private float getPowerValue()
    {
        float value = ItemList.getData(this.baseStats.item.id).powerPoints +
                      ItemList.getData(this.head.item.id).powerPoints +
                      ItemList.getData(this.shoulder.item.id).powerPoints +
                      ItemList.getData(this.chest.item.id).powerPoints +
                      ItemList.getData(this.legs.item.id).powerPoints +
                      ItemList.getData(this.hands.item.id).powerPoints +
                      ItemList.getData(this.boots.item.id).powerPoints +
                      ItemList.getData(this.mainHand.item.id).powerPoints +
                      ItemList.getData(this.offHand.item.id).powerPoints;

        return value;
    }

    private float getReductionValue()
    {
        float value = ItemList.getData(this.baseStats.item.id).reductionPoints +
                      ItemList.getData(this.head.item.id).reductionPoints +
                      ItemList.getData(this.shoulder.item.id).reductionPoints +
                      ItemList.getData(this.chest.item.id).reductionPoints +
                      ItemList.getData(this.legs.item.id).reductionPoints +
                      ItemList.getData(this.hands.item.id).reductionPoints +
                      ItemList.getData(this.boots.item.id).reductionPoints +
                      ItemList.getData(this.mainHand.item.id).reductionPoints +
                      ItemList.getData(this.offHand.item.id).reductionPoints;

        return value;
    }

    private float getHasteValue()
    {
        float value = ItemList.getData(this.baseStats.item.id).hastePoints +
                      ItemList.getData(this.head.item.id).hastePoints +
                      ItemList.getData(this.shoulder.item.id).hastePoints +
                      ItemList.getData(this.chest.item.id).hastePoints +
                      ItemList.getData(this.legs.item.id).hastePoints +
                      ItemList.getData(this.hands.item.id).hastePoints +
                      ItemList.getData(this.boots.item.id).hastePoints +
                      ItemList.getData(this.mainHand.item.id).hastePoints +
                      ItemList.getData(this.offHand.item.id).hastePoints;

        return value;
    }

    private float getMovementSpeedValue()
    {
        float value = ItemList.getData(this.baseStats.item.id).movementSpeedPoints +
                      ItemList.getData(this.head.item.id).movementSpeedPoints +
                      ItemList.getData(this.shoulder.item.id).movementSpeedPoints +
                      ItemList.getData(this.chest.item.id).movementSpeedPoints +
                      ItemList.getData(this.legs.item.id).movementSpeedPoints +
                      ItemList.getData(this.hands.item.id).movementSpeedPoints +
                      ItemList.getData(this.boots.item.id).movementSpeedPoints +
                      ItemList.getData(this.mainHand.item.id).movementSpeedPoints +
                      ItemList.getData(this.offHand.item.id).movementSpeedPoints;

        return value;
    }

    private void updateEquippedDisplay()
    {
        this.headSlot = this.head.item.name;
        this.shoulderSlot = this.shoulder.item.name;
        this.chestSlot = this.chest.item.name;
        this.legsSlot = this.legs.item.name;
        this.bootsSlot = this.boots.item.name;
        this.handsSlot = this.hands.item.name;
        this.mainHandSlot = this.mainHand.item.name;
        this.offhandSlot = this.offHand.item.name;

        OnChangeItem(this);
    }

    public void equipItem(int anId)
    {
        if(ItemList.itemExists(anId))
        {
            Item i = new Item(anId);
            if(i.type == ItemType.Equipment)
            {
                switch(i.slot)
                {
                    case EquipSlot.Head:
                        this.head.add(i);
                        break;

                    case EquipSlot.Shoulders:
                        this.shoulder.add(i);
                        break;

                    case EquipSlot.Chest:
                        this.chest.add(i);
                        break;

                    case EquipSlot.Legs:
                        this.legs.add(i);
                        break;

                    case EquipSlot.Hands:
                        this.hands.add(i);
                        break;

                    case EquipSlot.Boots:
                        this.boots.add(i);
                        break;

                    case EquipSlot.MainHand:
                        this.mainHand.add(i);
                        break;

                    case EquipSlot.OffHand:
                        this.offHand.add(i);
                        break;
                }

                this.updateStats();
                this.updateValuesText();
                this.updateEquippedDisplay();
            }
        }
    }

    // Clears the given slot
    public void unequipItem(EquipSlot aSlot)
    {
        switch(aSlot)
        {
            case EquipSlot.Head:
                this.head.remove();
                break;

            case EquipSlot.Shoulders:
                this.shoulder.remove();
                break;

            case EquipSlot.Chest:
                this.chest.remove();
                break;

            case EquipSlot.Legs:
                this.legs.remove();
                break;

            case EquipSlot.Hands:
                this.hands.remove();
                break;

            case EquipSlot.Boots:
                this.boots.remove();
                break;

            case EquipSlot.MainHand:
                this.mainHand.remove();
                break;

            case EquipSlot.OffHand:
                this.offHand.remove();
                break;
        }

        this.updateStats();
        this.updateValuesText();
        this.updateEquippedDisplay();
    }
}
