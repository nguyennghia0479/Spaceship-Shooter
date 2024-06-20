using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Effect/Health Effect Info")]
public class HealEffectInfo : ItemEffectInfo
{
    [SerializeField] private int healthPoint;

    public override void ExecuteItemEffect()
    {
        Health health = PlayerManager.Instance.playerShip.GetComponent<Health>();

        health.IncreaseHealth(healthPoint);
    }
}
