using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Inventory inventory;

    // Sprite used upon selected or deselected.
    public Sprite selectedBorder;
    public Sprite defaultBorder;

    // Background sprite used during cooldown.
    public Sprite cooldownBackground;

    // Use this for initialization
    void Start () {
        inventory.ItemAdded += InventoryUIItemAdded;
        inventory.ItemEquipped += InventoryUIItemSelected;
	}

    private void InventoryUIItemSelected(object sender, ItemEquippedEventArgs e) {
        int key = 1;
        foreach (Transform slot in transform)
        {
            Image image = slot.Find("border").GetComponent<Image>();

            if (key == e.index)
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
            Image image = slot.Find("border").Find("item").GetComponent<Image>();

            // We found the empty slot.
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.item.Image;
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

            // Get the cooldown background. 
            Image image = slot.Find("cooldown").GetComponent<Image>();

            // If the item is still cooling down, show a gray background
            // with its size based on the cooldown time.
            if (item != null && inventory.getTimeUntilNextUse(item) > 0)
            {
                image.enabled = true;
                float ratio = inventory.getTimeUntilNextUse(item) / item.Cooldown;
                image.rectTransform.localScale = new Vector3(1, ratio, 1);
                image.sprite = cooldownBackground;
            }
            else
            {
                image.enabled = false;
            }
            key++;
        }
    }

    private void Update()
    {
        UpdateBackground();
    }
}
