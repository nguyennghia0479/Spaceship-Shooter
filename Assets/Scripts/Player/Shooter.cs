using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float moveSpeed;
    [SerializeField] private Transform guns;
    [SerializeField] private float fireRate;

    private float defaultFireRate;
    private GameObject defaultProjectile;
    private ProjectileHolder projectileHolder;
    private bool isShootLaserLarge;

    protected virtual void Start()
    {
        defaultFireRate = fireRate;
        defaultProjectile = projectilePrefab;
        projectileHolder = FindObjectOfType<ProjectileHolder>();
        if (projectileHolder == null)
        {
            Debug.LogWarning("Projectile Holder is null.");
            return;
        }

        StartCoroutine(FireProjectileRoutine());
    }

    protected virtual IEnumerator FireProjectileRoutine()
    {
        while (true)
        {
            foreach (Transform gun in guns)
            {
                SetupProjectile(gun.position);

                PlayShootSound();
            }

            yield return new WaitForSeconds(fireRate);

        }
    }

    protected virtual void SetupProjectile(Vector3 firePosition)
    {
        GameObject newProjectile = Instantiate(projectilePrefab, firePosition, Quaternion.identity, projectileHolder.transform);
        if (newProjectile.TryGetComponent(out Rigidbody2D rb))
        {
            rb.velocity = transform.up * moveSpeed;
        }
    }

    private void PlayShootSound()
    {
        if (isShootLaserLarge)
        {
            SoundManager.Instance.PlayShootLaserLarge(transform.position);
        }
        else
        {
            SoundManager.Instance.PlayShootLaserSmall(transform.position);
        }
    }

    #region Buff stats
    public void IncreaseFireRate(float fireRatePercentage, float duration)
    {
        StartCoroutine(IncreaseFireRateRoutine(fireRatePercentage, duration));
    }

    private IEnumerator IncreaseFireRateRoutine(float fireRatePercentage, float duration)
    {
        fireRate -= fireRate * fireRatePercentage;

        yield return new WaitForSeconds(duration);

        fireRate = defaultFireRate;
    }

    public void UpgradeProjectile(GameObject projectileUpgradePrefab, float duration)
    {
        StartCoroutine(UpgradeProjectileRoutine(projectileUpgradePrefab, duration));
    }

    private IEnumerator UpgradeProjectileRoutine(GameObject projectileUpgradePrefab, float duration)
    {
        projectilePrefab = projectileUpgradePrefab;
        isShootLaserLarge = true;

        yield return new WaitForSeconds(duration);

        projectilePrefab = defaultProjectile;
        isShootLaserLarge = false;
    }

    #endregion
}
