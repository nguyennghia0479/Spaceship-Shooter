using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;

    public void Hit()
    {
        if (GetComponent<EnemyBoss>() != null) return;

        Destroy(gameObject);
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
