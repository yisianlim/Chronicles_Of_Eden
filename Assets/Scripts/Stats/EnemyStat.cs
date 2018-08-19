using UnityEngine;

public class EnemyStat : Stat
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

    public override void TakeDamage(int damage, Vector3 playerDirection)
    {
        currentHealth -= damage;
        Mathf.Clamp(currentHealth, 0, maxHealth);

        Vector3 hitDirection = playerDirection - transform.position;
        hitDirection = -hitDirection.normalized;

        // Enable particle system.
        ParticleSystem.EmissionModule module = ps.emission;
        module.enabled = true;
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.FromToRotation(Vector3.forward, hitDirection)) as GameObject, 2);

        if (currentHealth <= 0)
        {
            // Destroy enemy.
            GetComponent<NPCAI>().enabled = false;
            enemyAnimator.Dies();
            Destroy(enemy, 2);
        }
    }
}
