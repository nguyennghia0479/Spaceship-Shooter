using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditUI : MonoBehaviour
{
    [SerializeField] private Button closeBtn;

    private void Awake()
    {
        closeBtn.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    public void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
