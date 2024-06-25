using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Info")]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;
    [Range(0f, 100f)]
    [SerializeField] private float dropChance;
    [SerializeField] private List<ItemEffectInfo> effects;

    public void ExecuteItemEffect()
    {
        foreach (ItemEffectInfo effect in effects)
        {
            effect.ExecuteItemEffect();
        }
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public float GetDropChance()
    {
        return dropChance;
    }
}
