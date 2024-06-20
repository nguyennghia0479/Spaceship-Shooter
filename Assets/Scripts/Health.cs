using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] private ParticleSystem explosionParticlePrefab;

    protected int currentHealth;
    private float armorPercentage;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DamageDealer damageDealer))
        {
            damageDealer.Hit();
            HitEffect();
            TakeDamage(damageDealer.GetDamage());
        }
    }

    protected virtual void TakeDamage(int damage)
    {
        damage = CheckTargetArmor(damage);

        currentHealth -= damage;

        Die();
    }

    protected virtual void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private int CheckTargetArmor(int damage)
    {
        if (armorPercentage > 0)
        {
            damage -= Mathf.RoundToInt(damage * armorPercentage);
            if (damage < 0)
            {
                damage = 0;
            }
        }

        return damage;
    }

    private void HitEffect()
    {
        ParticleSystem newExplosionParticle = Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);
        Destroy(newExplosionParticle.gameObject, newExplosionParticle.main.duration + newExplosionParticle.main.startLifetime.constantMax);
    }

    #region Buff stats

    public void IncreaseHealth(int health)
    {
        currentHealth += health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void IncreaseArmor(float armorPercentage, float duration)
    {
        StartCoroutine(IncreaseArmorRoutine(armorPercentage, duration));
    }

    private IEnumerator IncreaseArmorRoutine(float armorPercentage, float duration)
    {
        this.armorPercentage = armorPercentage;

        yield return new WaitForSeconds(duration);

        this.armorPercentage = 0;
    }

    #endregion
}
