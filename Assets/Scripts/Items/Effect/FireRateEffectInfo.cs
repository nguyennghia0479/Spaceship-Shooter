using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Effect/Fire Rate Effect Info")]
public class FireRateEffectInfo : ItemEffectInfo
{
    [Range(0f, 1f)]
    [SerializeField] private float fireRatePercentage;
    [SerializeField] private float duration;

    public override void ExecuteItemEffect()
    {
        base.ExecuteItemEffect();

        Shooter shooter = PlayerManager.Instance.playerShip.GetComponent<Shooter>();
        shooter.IncreaseFireRate(fireRatePercentage, duration); 
    }
}
