using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : Singleton<BackgroundManager>
{
    [SerializeField] private ListPrefabInfo listBackground;

    private GameObject background;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
        UpdateBackground();
    }

    public void UpdateBackground()
    {
        if (background != null)
        {
            Destroy(background);
        }

        int randomBG = Random.Range(0, listBackground.GetCount());
        background = Instantiate(listBackground.GetByIndex(randomBG), transform);
    }
}
