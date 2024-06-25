using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Effect/Speed Effect Info")]
public class SpeedEffectInfo : ItemEffectInfo
{
    [Range(0f, 1f)]
    [SerializeField] private float speedPercentage;
    [SerializeField] private float duration;

    public override void ExecuteItemEffect()
    {
        base.ExecuteItemEffect();

        PlayerShip playerShip = PlayerManager.Instance.playerShip;
        playerShip.IncreaseSpeed(speedPercentage, duration);
    }
}
