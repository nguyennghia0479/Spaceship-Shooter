using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Shooter
{
    [Header("AI")]
    [SerializeField] private float minFireRate;
    [SerializeField] private float maxFireRate;
  

    private EnemyBoss enemyBoss;
    private bool isFire = true;

    protected override void Start()
    {
        if (TryGetComponent(out EnemyBoss enemyBoss))
        {
            this.enemyBoss = enemyBoss;
            isFire = false;
        }

        base.Start();
    }

    private void Update()
    {
        if (enemyBoss != null)
        {
            if (enemyBoss.GetEnemyState() == EnemyState.Shooter)
            {
                isFire = true;
            }
        }
    }

    protected override IEnumerator FireProjectileRoutine()
    {
        while (true)
        {
            if (isFire)
            {
                EnemyFire();
            }

            yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        }
    }

    protected override void SetupProjectile(Vector3 firePosition)
    {
        base.SetupProjectile(firePosition);
    }

    protected override void PlayShootSound()
    {
        SoundManager.Instance.PlayShootLaserSmall(transform.position);
    }

    private void EnemyFire()
    {
        if (guns != null)
        {
            foreach (Transform gun in guns)
            {
                SetupProjectile(gun.position);
                PlayShootSound();
            }
        }
        else
        {
            SetupProjectile(transform.position);
            PlayShootSound();
        }
    }
}
