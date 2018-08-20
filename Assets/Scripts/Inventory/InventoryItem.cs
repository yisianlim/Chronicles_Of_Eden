using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public interface  {
//    string Name { get; }

//    Sprite Image { get; }

//    void OnPickUp();
//}

public class InventoryEventArgs : EventArgs {

    public EquipableItem Item;

    public InventoryEventArgs(EquipableItem item) {
        Item = item;
    }
}

public class ItemEquippedEventArgs : EventArgs
{

    public int Index;

    public ItemEquippedEventArgs(int index)
    {
        Index = index;
    }
}



