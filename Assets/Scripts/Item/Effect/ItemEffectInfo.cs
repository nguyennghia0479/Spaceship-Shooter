using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectInfo : ScriptableObject
{
    [TextArea]
    [SerializeField] protected string itemEffectDes;

    public virtual void ExecuteItemEffect()
    {

    }
}
