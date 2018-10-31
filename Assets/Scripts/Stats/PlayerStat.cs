using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : Stat {
    public int maxHealth = 500;
    public int currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public override void TakeDamage(int damage, Vector3 enemyDirection)
    {
        currentHealth -= damage;
        Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
