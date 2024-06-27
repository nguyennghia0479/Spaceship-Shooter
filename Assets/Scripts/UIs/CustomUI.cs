using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomUI : MonoBehaviour
{
    [SerializeField] private Image shipSelected;
    [SerializeField] private Image shipImage;
    [Space]
    [SerializeField] private Button backwardBtn;
    [SerializeField] private Button forwardBtn;
    [Space]
    [SerializeField] private TextMeshProUGUI shipNo;
    [SerializeField] private Button closeBtn;
    [SerializeField] private ListPrefabInfo listPlayerShipInfo;
    [Header("Stats Info")]
    [SerializeField] private Image[] damageDots;
    [SerializeField] private Image[] healthDots;
    [SerializeField] private Image[] speedDots;

    private int index = 0;

    private const string PLAYER_SHIP_SELECTED = "PlayerShipSelected";

    private void Awake()
    {
        backwardBtn.onClick.AddListener(() =>
        {
            BackwardOption();
        });

        forwardBtn.onClick.AddListener(() =>
        {
            ForwardOption();
        });

        closeBtn.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {
        Hide();
        index = PlayerPrefs.GetInt(PLAYER_SHIP_SELECTED, 0);
        UpdateShip(index);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void BackwardOption()
    {
        index--;
        if (index < 0)
        {
            index = listPlayerShipInfo.GetCount() - 1;
        }

        UpdateShip(index);
    }

    private void ForwardOption()
    {
        index++;
        if (index >= listPlayerShipInfo.GetCount())
        {
            index = 0;
        }

        UpdateShip(index);
    }

    private void UpdateShip(int index)
    {
        GameObject currentShip = listPlayerShipInfo.GetByIndex(index);
        shipImage.sprite = currentShip.GetComponentInChildren<SpriteRenderer>().sprite;
        shipSelected.sprite = shipImage.sprite;
        shipNo.text = (index + 1).ToString() + "/" + listPlayerShipInfo.GetCount();

        PlayerStats stats = currentShip.GetComponent<PlayerStats>();
        UpdateDamageStats(stats);
        UpdateHealthStats(stats);
        UpdateSpeedStats(stats);

        PlayerPrefs.SetInt(PLAYER_SHIP_SELECTED, index);
        PlayerPrefs.Save();
    }

    private void UpdateDamageStats(PlayerStats stats)
    {
        int value = stats.GetDamage();

        for (int i = 0; i < damageDots.Length; i++)
        {
            damageDots[i].enabled = i < value;
        }
    }

    private void UpdateHealthStats(PlayerStats stats)
    {
        int value = stats.GetHealth();

        for (int i = 0; i < healthDots.Length; i++)
        {
            healthDots[i].enabled = i < value;
        }
    }

    private void UpdateSpeedStats(PlayerStats stats)
    {
        int value = stats.GetSpeed();

        for (int i = 0; i < speedDots.Length; i++)
        {
            speedDots[i].enabled = i < value;
        }
    }
}
