using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APBarUI : MonoBehaviour {

    public PlayerController playerController;

    // AP stats.
    private float maxAP = 1.0f;
    private float currentAP;

    // AP UI.
    public Image APBar;

    // Dogde and dodge cool down duration based on the player controller.
    // Used to decrease the bar. 
    private float dodgeDuration;
    private float dodgeCoolDownDuration; 

    private void Awake()
    {
        currentAP = maxAP;
        dodgeDuration = playerController.DodgeDuration;
        dodgeCoolDownDuration = playerController.DodgeCoolDownDuration;
    }

    void Update () {
        // If player is dogding then we decrease the bar. 
        if (playerController.isDodging())
        {
            currentAP -= 1.0f / dodgeDuration * Time.deltaTime;
            currentAP = currentAP < 0 ? 0 : currentAP;
        }
        // If player is cooling down, then we fill the bar.
        else if (playerController.isCoolingDown()) {
            currentAP += 1.0f / dodgeCoolDownDuration * Time.deltaTime;
            currentAP = currentAP > maxAP ? maxAP : currentAP;
        }

        // Update the bar display.
        float ratio = currentAP / maxAP;
        APBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
