using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Effect/Health Effect Info")]
public class HealEffectInfo : ItemEffectInfo
{
    [Range(0, 1)]
    [SerializeField] private float healthPercentage;

    public override void ExecuteItemEffect()
    {
        base.ExecuteItemEffect();

        Health health = PlayerManager.Instance.playerShip.GetComponent<Health>();
        int healthAdd = Mathf.RoundToInt(health.GetMaxHealth() * healthPercentage);
        health.IncreaseHealth(healthAdd);
    }
}
