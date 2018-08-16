using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public GameObject deathEffect;
    public ParticleSystem ps;
    public GameObject enemy;
    public int maxHealth = 10;
    public int currentHealth { get; private set; }

    private EnemyAnimator enemyAnimator;

    private void Awake()
    {
        enemyAnimator = GetComponent<EnemyAnimator>();
        ps = deathEffect.GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule module = ps.emission;
        module.enabled = false;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, Vector3 playerDirection)
    {
        currentHealth -= damage;
        Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0) {
            Vector3 hitDirection = playerDirection - transform.position;
            hitDirection = -hitDirection.normalized;

            // Enable particle system.
            ParticleSystem.EmissionModule module = ps.emission;
            module.enabled = true;

            // Destroy enemy.
            enemyAnimator.Dies();
            Destroy(Instantiate(deathEffect, transform.position, Quaternion.FromToRotation(Vector3.forward, hitDirection)) as GameObject, 2);
            Destroy(enemy, 2);
        }
    }
}
