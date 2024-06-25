using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Effect/Projectile Effect Info")]
public class ProjectileEffectInfo : ItemEffectInfo
{
    [SerializeField] private GameObject projectileUpgradePrefab;
    [SerializeField] private float duration;

    public override void ExecuteItemEffect()
    {
        base.ExecuteItemEffect();

        Shooter shooter = PlayerManager.Instance.playerShip.GetComponent<Shooter>();
        shooter.UpgradeProjectile(projectileUpgradePrefab, duration);
    }
}
