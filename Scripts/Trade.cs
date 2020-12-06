using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.Events;

public class Trade : MonoBehaviour
{
    public GameObject tradeCanvas;

    public TextMeshProUGUI inventoryText;

    public UnityEvent onRefreshUI;

    [HideInInspector]
    public List<ItemInstance> inventory;

    [HideInInspector]
    public List<CatalogItem> catalog;

    public static Trade instance;

    void Awake()
    {
        instance = this;
    }    

    public void OnLoggedIn()
    {
        tradeCanvas.SetActive(true);
        if (onRefreshUI != null)
            onRefreshUI.Invoke();
    }

    public void GetInventory()
    {
        inventoryText.text = "";

        // request to get the player's inventory
        GetPlayerCombinedInfoRequest getInvRequest = new GetPlayerCombinedInfoRequest
        {
            PlayFabId = Login_Register.instance.playFabId,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetUserInventory = true
            }
        };

        PlayFabClientAPI.GetPlayerCombinedInfo(getInvRequest,
        result =>
        {
            inventory = result.InfoResultPayload.UserInventory;
            foreach (ItemInstance item in inventory)
                inventoryText.text += item.DisplayName + ", ";
        },

        error => Debug.Log(error.ErrorMessage)

        );
    }

    public void GetCatalog()
    {
        GetCatalogItemsRequest getCatalogRequest = new GetCatalogItemsRequest
        {
            CatalogVersion = "PlayerItems"
        };

        PlayFabClientAPI.GetCatalogItems(getCatalogRequest,
        result => catalog = result.Catalog,
        error => Debug.Log(error.ErrorMessage)
        );
    }
}
