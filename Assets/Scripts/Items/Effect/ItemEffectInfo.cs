using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectInfo : ScriptableObject
{
    [TextArea]
    [SerializeField] protected string itemEffectDes;
    [SerializeField] private ParticleSystem particleEffectPrefab;

    public virtual void ExecuteItemEffect()
    {
        PlayerShip playerShip = PlayerManager.Instance.playerShip;
        ParticleSystem newParticleEffect = Instantiate(particleEffectPrefab, playerShip.transform.position, Quaternion.identity, playerShip.transform);
        Destroy(newParticleEffect.gameObject, newParticleEffect.main.duration + newParticleEffect.main.startLifetime.constantMax);
    }
}
