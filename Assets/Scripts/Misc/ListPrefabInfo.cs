using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "List Prefab Info")]
public class ListPrefabInfo : ScriptableObject
{
    [SerializeField] private GameObject[] prefabs;

    public int GetCount()
    {
        return prefabs.Length;
    }

    public GameObject GetByIndex(int index)
    {
        return prefabs[index];
    }
}
