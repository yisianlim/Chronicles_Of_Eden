using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField] Transform userTranform; //The transform of the user using this inventory.

    [SerializeField] private EquipableItem[] items;
    private float[] timesUntilNextUse; //How long before an item can be used again.

    private int equipedItem = 0; //The index of the currently equiped item. 
    public EquipableItem EquippedItem { get { return items[equipedItem]; } }

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<ItemEquippedEventArgs> ItemEquipped;

    private void Start()
    {
        timesUntilNextUse = new float[items.Length];
    }

    private void Update()
    {

        //If the user presses the mouse button, use the equipped item if it exists and is not still cooling down.
        if (Input.GetMouseButtonDown(0)) {
            if (items[equipedItem] != null && timesUntilNextUse[equipedItem] <= 0)
            {
                items[equipedItem].Use(userTranform, this);
                timesUntilNextUse[equipedItem] = items[equipedItem].Cooldown; //Start the cooldown for the used item.
            }
        }

        //If the user presses a number key, equip the item of that number, if it exists.
        for (int key = 0; key < items.Length; key++)
        {
            if (Input.GetKeyDown(key + "") && items[key] != null)
                SlotSelected(key);
        }

        //Decrease the cooldown counter for all the items.
        for(int i = 0; i < timesUntilNextUse.Length; i++) {
            if(timesUntilNextUse[i] > 0) timesUntilNextUse[i] -= Time.deltaTime;
        }

    }

    /// <summary>
    /// Called when the slot with the given number has been selected.
    /// </summary>
    /// <param name="num"></param>
    protected virtual void SlotSelected(int num)
    {
        equipedItem = num;
        ItemEquipped(this, new ItemEquippedEventArgs(num));
    }

    /// <summary>
    /// Get the item at the spot with the given number in the inventory.
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    protected EquipableItem GetItemAt(int num)
    {
        return items[num];
    }

    /// <summary>
    /// Returns the position of the given item in the inventory, or -1 if it's not there.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int getPositionOfItem(EquipableItem item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (item == items[i]) return i;
        }

        return -1;
    }

    /// <summary>
    /// Add the given item at the first avaliable position in the inventory.
    /// </summary>
    public virtual void AddItem(EquipableItem item)
    {
        for (int i = 1; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                items[i] = item;

                // Item added event is raised and subscribers are notified.
                if (ItemAdded != null) {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
                return;
            }
        }
           
    }

}
