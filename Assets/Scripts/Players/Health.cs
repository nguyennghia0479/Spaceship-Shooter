using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] private ParticleSystem explosionParticlePrefab;

    public event Action<float> OnHealthChange;

    protected int currentHealth;
    private float armorPercentage;
    private CameraShake cameraShake;

    protected virtual void Start()
    {
        if (TryGetComponent(out PlayerShip _) && TryGetComponent(out PlayerStats playerStats))
        {
            maxHealth = playerStats.GetHealth() * 100;
        }

        currentHealth = maxHealth;
        InvokeOnHealthChange();

        cameraShake = Camera.main.GetComponent<CameraShake>();
        if (cameraShake == null)
        {
            Debug.LogWarning("Camera Shake in null.");
            return;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DamageDealer damageDealer))
        {
            damageDealer.Hit();
            HitEffect(collision.transform.position);
            TakeDamage(damageDealer.GetDamage());
        }
    }

    protected virtual void TakeDamage(int damage)
    {
        damage = CheckTargetArmor(damage);

        currentHealth -= damage;
        InvokeOnHealthChange();

        if (cameraShake != null)
        {
            cameraShake.PlayCameraShake();
        }

        Die();
    }

    protected virtual void Die()
    {
        if (currentHealth <= 0)
        {
            SoundManager.Instance.PlayShipExplosionSound(transform.position);
            LevelManager.Instance.LoadGameOverScene();

            Destroy(gameObject);
        }
    }

    protected virtual void InvokeOnHealthChange()
    {
        OnHealthChange?.Invoke(currentHealth);
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

    private void HitEffect(Vector3 position)
    {
        ParticleSystem newExplosionParticle = Instantiate(explosionParticlePrefab, position, Quaternion.identity);
        Destroy(newExplosionParticle.gameObject, newExplosionParticle.main.duration + newExplosionParticle.main.startLifetime.constantMax);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    #region Buff stats

    public void IncreaseHealth(int health)
    {
        currentHealth += health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthChange?.Invoke(currentHealth);
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
