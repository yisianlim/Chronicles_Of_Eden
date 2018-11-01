using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour {

    public Stat stat;
    public Image HPImage;

    private int maxHP;
    private int currentHP;

    private void Awake()
    {
        maxHP = stat.maxHealth;
    }

    void Update () {
        currentHP = stat.currentHealth;
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
