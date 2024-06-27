using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int health;
    [SerializeField] private int speed;

    public int GetDamage() { return damage; }

    public int GetHealth() { return health; }

    public int GetSpeed() { return speed; }
}
