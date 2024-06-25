using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemObjectPrefab;
    [SerializeField] private List<ItemInfo> items;

    private bool isGenerate = true;

    public void GenerateItemDrop()
    {
        while (isGenerate)
        {
            if (items.Count <= 0)
            {
                return;
            }

            ItemInfo item = items[Random.Range(0, items.Count)];
            items.Remove(item);

            if (Random.Range(0f, 100f) < item.GetDropChance())
            {
                DropItem(item);
                isGenerate = false;
            }
        }
    }

    private void DropItem(ItemInfo item)
    {
        GameObject newItemObject = Instantiate(itemObjectPrefab, transform.position, Quaternion.identity);
        newItemObject.GetComponent<ItemObject>().SetupItemObject(item);
    }
}
