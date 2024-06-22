using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private ItemInfo itemInfo;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.down * moveSpeed;
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerShip _))
        {
            itemInfo.ExecuteItemEffect();
            SoundManager.Instance.PlayExecuteItemSound();

            Destroy(gameObject);
        }
    }

    public void SetupItemObject(ItemInfo itemInfo)
    {
        if (itemInfo == null)
        {
            Destroy(gameObject);
            return;
        }

        this.itemInfo = itemInfo;
        sr.sprite = itemInfo.GetIcon();
    }
}
