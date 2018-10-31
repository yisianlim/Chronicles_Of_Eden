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

    // Flag to check when we need to continually fill up the bar. 
    private bool fillBar = false;

    void Awake () {
        inventory.ItemEquipped += UpdateEquippedItem;
    }

    private void UpdateEquippedItem(object sender, ItemEquippedEventArgs e) {
        currentEquippedItem = inventory.EquippedItem;
        maxAP = currentEquippedItem.Cooldown;
        currentAP = maxAP;
        fillBar = true;
    }

    void Update () {
        // If there is not item equipped, just show an empty bar.
        if (currentEquippedItem == null) {
            APBar.rectTransform.localScale = new Vector3(0, 1, 1);
            return;
        }

        if (fillBar == true)
        {
            // Increase AP over a period of time (instead of an instant increase)
            // when the item is first equipped.
            currentAP -= 1.0f / 0.4f * Time.deltaTime;
            fillBar = currentAP > 0;
        }
        else
        {
            // Since item already equipped, just update the cool down time. 
            currentAP = inventory.getTimeUntilNextUse(currentEquippedItem);
        }
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
