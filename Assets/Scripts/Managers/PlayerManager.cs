using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private ListPrefabInfo listPlayerShipInfo;
    [HideInInspector] public PlayerShip playerShip;

    private const string PLAYER_SHIP_SELECTED = "PlayerShipSelected";

    protected override void Awake()
    {
        base.Awake();

        GameObject playerShipSelected = listPlayerShipInfo.GetByIndex(PlayerPrefs.GetInt(PLAYER_SHIP_SELECTED, 0));
        GameObject newPlayerShip = Instantiate(playerShipSelected);
        playerShip = newPlayerShip.GetComponent<PlayerShip>();
    }
}
