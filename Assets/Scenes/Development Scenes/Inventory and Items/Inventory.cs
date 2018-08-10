using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private EquipableItem[] items = new EquipableItem[9];

    private void Update()
    {

        //If the user hasn't pressed the left mouse button, don't do anything.
        if (!Input.GetMouseButtonDown(0)) return;

    }

}
