using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : Health
{
    [SerializeField] private int scorePoint;

    private EnemyBoss enemyBoss;
    private EnemySpawner enemySpawner;
    private ItemDrop itemDrop;

    protected override void Start()
    {
        base.Start();

        enemyBoss = GetComponent<EnemyBoss>();
        enemySpawner = GetComponentInParent<EnemySpawner>();
        itemDrop = GetComponent<ItemDrop>();
    }

    protected override void TakeDamage(int damage)
    {
        if (enemyBoss != null && enemyBoss.GetEnemyState() == EnemyState.Prepare)
        {
            return;
        }

        currentHealth -= damage;
        InvokeOnHealthChange();
        Die();
    }

    protected override void Die()
    {
        if (currentHealth <= 0)
        {
            BossDie();
            ScoreManager.Instance.AddScorePoint(scorePoint);
            SoundManager.Instance.PlayShipExplosionSound(transform.position);

            Destroy(gameObject);
        }
    }

    private void BossDie()
    {
        if (enemyBoss != null && enemySpawner != null)
        {
            if (itemDrop != null)
            {
                itemDrop.GenerateItemDrop();
            }

            enemySpawner.BossDead();
        }
    }
}
