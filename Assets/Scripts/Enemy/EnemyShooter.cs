using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Shooter
{
    [Header("AI")]
    [SerializeField] private float minFireRate;
    [SerializeField] private float maxFireRate;

    protected override void Start()
    {
        base.Start();
    }

    protected override IEnumerator FireProjectileRoutine()
    {
        while (true)
        {
            SetupProjectile(transform.position);

            yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        }
    }

    protected override void SetupProjectile(Vector3 firePosition)
    {
        base.SetupProjectile(firePosition);
    }
}
