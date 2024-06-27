using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] Image[] healthDots;

    private Health health;

    private void Start()
    {
        if (PlayerManager.Instance.playerShip.TryGetComponent(out Health health))
        {
            this.health = health;
            UpdateHealth(health.GetCurrentHealth());

            health.OnHealthChange += UpdateHealth;
        }
    }

    private void Update()
    {
        scoreText.text = ScoreManager.Instance.GetScorePoint().ToString("000000000");
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.OnHealthChange -= UpdateHealth;
        }
    }

    private void UpdateHealth(float currentHealth)
    {
        float maxHealthDot = health.GetMaxHealth() / healthDots.Length;    

        for (int i = 0; i < healthDots.Length; i++)
        {
            float healthDot = Mathf.Min(currentHealth, maxHealthDot);
            currentHealth -= maxHealthDot;
            currentHealth = currentHealth <= 0 ? 0 : currentHealth;
            healthDots[i].fillAmount = healthDot / maxHealthDot;
        }
    }

}
