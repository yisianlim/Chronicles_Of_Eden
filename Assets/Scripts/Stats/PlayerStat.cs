using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {
    public int maxHealth = 500;
    public int currentHealth { get; private set; }

    public Image HPImage;

    public PlayerController playerController;

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthBarDisplay();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void UpdateHealthBarDisplay() {
        float ratio = (float)currentHealth / (float)maxHealth;
        HPImage.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeDamage(int damage, Vector3 enemyDirection)
    {
        currentHealth -= damage;
        Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBarDisplay();

        // Determine the hit direction, which is the difference between the enemy and player.
        Vector3 hitDirection = enemyDirection - playerController.transform.position;
        hitDirection = -hitDirection.normalized;
        playerController.KnockBack(hitDirection);
    }
}
