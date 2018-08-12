using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {
    public int maxHealth = 500;
    public int currentHealth { get; private set; }

    public Image HPImage;

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthBarDisplay();
    }

    private void UpdateHealthBarDisplay() {
        float ratio = currentHealth / maxHealth;
        HPImage.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBarDisplay();

        Debug.Log("Health:" + currentHealth);
    }
}
