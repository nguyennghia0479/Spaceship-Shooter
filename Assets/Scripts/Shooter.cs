using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float moveSpeed;
    [SerializeField] private Transform guns;
    [SerializeField] private float fireRate;

    private ProjectileHolder projectileHolder;

    protected virtual void Start()
    {
        projectileHolder = FindObjectOfType<ProjectileHolder>();

        StartCoroutine(FireProjectileRoutine());
    }

    protected virtual IEnumerator FireProjectileRoutine()
    {
        while (true)
        {
            foreach (Transform gun in guns)
            {
                SetupProjectile(gun.position);
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
}
