using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Inventory inventory;

    // Sprite used upon selected or deselected.
    public Sprite selectedBorder;
    public Sprite defaultBorder;

    // Background sprite used during cooldown or default.
    public Sprite cooldownBackground;
    public Sprite defaultBackground;

    // Use this for initialization
    void Start () {
        inventory.ItemAdded += InventoryUIItemAdded;
        inventory.ItemEquipped += InventoryUIItemSelected;
	}

    private void InventoryUIItemSelected(object sender, ItemEquippedEventArgs e) {
        int key = 1;
        foreach (Transform slot in transform)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if (key == e.Index)
            {
                // We found the equipped slot.
                image.sprite = selectedBorder;
            }
            else
            {
                // All other slot should not be bordered!
                image.sprite = defaultBorder;
            }
            key++;
        }

    }

    private void InventoryUIItemAdded(object sender, InventoryEventArgs e) {

        foreach (Transform slot in transform)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            // We found the empty slot.
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }

    private void UpdateBackground()
    {
        int key = 1;
        foreach (Transform slot in transform)
        {
            // Get the respective item from inventory.
            EquipableItem item = inventory.GetItemAt(key);
            Image image = slot.GetComponent<Image>();

            // If the item is still cooling down, show a gray background.
            if (item != null && inventory.getTimeUntilNextUse(item) > 0)
            {
                image.sprite = cooldownBackground;
            }
            else {
                image.sprite = defaultBackground;
            }
            key++;
        }
    }

    private void Update()
    {
        UpdateBackground();
    }
}
