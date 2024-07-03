using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    private EnemyHealth enemyHealth;
    private float maxHealth;

    private void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
        if (enemyHealth == null )
        {
            Debug.LogWarning("EnemyHealth is null.");
            return;
        }

        maxHealth = enemyHealth.GetMaxHealth();   
        UpdateHealthUI(maxHealth);

        enemyHealth.OnHealthChange += UpdateHealthUI;
    }

    private void OnDestroy()
    {
        if ( enemyHealth != null )
        {
            enemyHealth.OnHealthChange -= UpdateHealthUI;
        }
    }

    private void UpdateHealthUI(float currentHealth)
    {
        float healthNormialized = currentHealth / maxHealth;
        healthBar.fillAmount = healthNormialized;
    }
}
