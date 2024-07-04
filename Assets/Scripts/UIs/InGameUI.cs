using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] Image[] healthDots;
    [SerializeField] private float increaseRate = 100;

    private Health health;
    private Animator animator;
    private float currentScorePoint;

    private const string IS_FLASHING = "IsFlashing";

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        if (PlayerManager.Instance.playerShip.TryGetComponent(out Health health))
        {
            this.health = health;
            UpdateHealth(health.GetCurrentHealth());

            health.OnHealthChange += UpdateHealth;

            if (animator != null)
            {
                animator.SetBool(IS_FLASHING, false);
            }
        }
    }

    private void Update()
    {
        int scorePoint = ScoreManager.Instance.GetScorePoint();
        if (currentScorePoint < scorePoint)
        {
            currentScorePoint += Time.deltaTime * increaseRate;
        }
        else
        {
            currentScorePoint = scorePoint;
        }

        scoreText.text = currentScorePoint.ToString("000000000");
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
        HealthFlashing(currentHealth);
        float maxHealthDot = health.GetMaxHealth() / healthDots.Length;    

        for (int i = 0; i < healthDots.Length; i++)
        {
            float healthDot = Mathf.Min(currentHealth, maxHealthDot);
            currentHealth -= maxHealthDot;
            currentHealth = currentHealth <= 0 ? 0 : currentHealth;
            healthDots[i].fillAmount = healthDot / maxHealthDot;
        }
    }

    private void HealthFlashing(float currentHealth)
    {
        if (animator == null) return;

        float healthFlashingShowAmount = .3f;
        bool isFlashing = currentHealth / health.GetMaxHealth() < healthFlashingShowAmount;
        animator.SetBool(IS_FLASHING, isFlashing);
    }
}
