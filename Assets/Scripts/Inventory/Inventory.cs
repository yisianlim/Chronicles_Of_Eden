using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [SerializeField] Transform userTranform; //The transform of the user using this inventory.

    [SerializeField] private EquipableItem[] items = new EquipableItem[10];
    private int equipedItem = 0; //The index of the currently equiped item. 
    public EquipableItem EquippedItem { get { return items[equipedItem]; } }

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<ItemEquippedEventArgs> ItemEquipped;


    private void Update()
    {

        //If the user hasn't pressed the left mouse button, don't do anything.
        if (Input.GetMouseButtonDown(0)) {
            if (items[equipedItem] != null) items[equipedItem].Use(userTranform, this);
        }

        //If the user presses a number key, equipt the item of that number, if it exists.
        for (int key = 0; key < items.Length; key++)
        {
            if (Input.GetKeyDown(key + "") && items[key] != null)
                SlotSelected(key);
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
