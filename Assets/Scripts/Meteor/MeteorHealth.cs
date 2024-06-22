using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealth : Health
{
    [SerializeField] private int scorePoint;

    private ItemDrop itemDrop;

    protected override void Start()
    {
        base.Start();

        itemDrop = GetComponent<ItemDrop>();
    }

    protected override void Die()
    {
        if (currentHealth <= 0)
        {
            if (itemDrop != null)
            {
                itemDrop.GenerateItemDrop();
            }

            ScoreManager.Instance.AddScorePoint(scorePoint);
            Destroy(gameObject);
        }
    }
}
