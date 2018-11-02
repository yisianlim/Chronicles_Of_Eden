using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour {

    // Player stat.
    public Stat stat;
    private int maxHP;
    private int currentHP;

    // UI.
    public Image HPImage;

    private void Awake()
    {
        maxHP = stat.maxHealth;
    }

    void Update () {
        currentHP = stat.currentHealth;
        UpdateHealthBarDisplay();
	}

    /// <summary>
    /// Update the HP bar.
    /// </summary>
    private void UpdateHealthBarDisplay()
    {
        float ratio = (float)currentHP / (float)maxHP;
        HPImage.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
