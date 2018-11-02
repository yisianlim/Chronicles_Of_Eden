using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEventArgs : EventArgs {

    public EquipableItem item;

    public InventoryEventArgs(EquipableItem item) {
        this.item = item;
    }
}

public class ItemEquippedEventArgs : EventArgs
{

    public int index;

    public ItemEquippedEventArgs(int index)
    {
        this.index = index;
    }
}



