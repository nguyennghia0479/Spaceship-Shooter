using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealth : Health
{
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

            Destroy(gameObject);
        }
    }
}
