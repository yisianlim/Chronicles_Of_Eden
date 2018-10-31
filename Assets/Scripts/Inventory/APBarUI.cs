using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APBarUI : MonoBehaviour {

    public Inventory inventory;
    private EquipableItem currentEquippedItem;

    // AP stats.
    private float maxAP;
    private float currentAP;

    // AP UI.
    public Image APBar;

    void Awake () {
        inventory.ItemEquipped += UpdateEquippedItem;
    }

    private void UpdateEquippedItem(object sender, ItemEquippedEventArgs e) {
        currentEquippedItem = inventory.EquippedItem;
        maxAP = currentEquippedItem.Cooldown;
    }

    void Update () {
        // If there is not item equipped, just show an empty bar.
        if (currentEquippedItem == null) {
            APBar.rectTransform.localScale = new Vector3(0, 1, 1);
            return;

        }
        currentAP = inventory.getTimeUntilNextUse(currentEquippedItem);
        UpdateBarDisplay();	
	}

    private void UpdateBarDisplay()
    {
        // Inverse because we want to show a full bar when the cool down time is 0.
        float inverse = maxAP - currentAP;
        float ratio = inverse / maxAP;
        APBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
