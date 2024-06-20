using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Effect/Shield Effect Info")]
public class ShieldEffectInfo : ItemEffectInfo
{
    [SerializeField] private GameObject shieldPrefab;
    [Range(0f, 1f)]
    [SerializeField] private float armorPercentage;
    [SerializeField] private float duration;

    public override void ExecuteItemEffect()
    {
        PlayerShip playerShip = PlayerManager.Instance.playerShip;
        Health health = playerShip.GetComponent<Health>();

        health.IncreaseArmor(armorPercentage, duration);
        playerShip.AddShieldGuard(shieldPrefab, duration);
    }
}
