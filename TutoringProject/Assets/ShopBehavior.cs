using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ShopBehavior : MonoBehaviour
{
    [Serializable]
    public struct Item
    {
        public string itemName;
        public int itemCost;
        public GameObject itemObject;
        public Sprite itemIcon;
    }

    public Item[] shopItems;
    /// <summary>
    /// 0 = SWORD
    /// 1 = CARPET
    /// 2 = GUN
    /// 3 = HELMET
    /// </summary>

    public Transform itemSpawnPosition;
    public GameObject buttonPrefab;
    public Transform shopPanel;
    public Button closeShopButton;

    public void OpenShop()
    {
        for(int i = 0; i < shopItems.Length; i++)
        {
            GameObject shopButton = Instantiate(buttonPrefab, shopPanel);
            shopButton.GetComponent<Button>().onClick.RemoveAllListeners();
            shopButton.GetComponent<Button>().onClick.AddListener(() => BuyShopItem(i));
            shopButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = shopItems[i].itemName + " - $" + shopItems[i].itemCost;
        }

        shopPanel.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        for(int i = 0; i < shopPanel.childCount; i++)
        {
            Destroy(shopPanel.GetChild(i).gameObject);
        }

        shopPanel.gameObject.SetActive(false);
    }

    public void BuyShopItem(Item currentItem)
    {
        if (GameController.instance.BoltAmount >= currentItem.itemCost)
        {
            GameController.instance.ChangeBoltAmount(-currentItem.itemCost);
            // Create Object at itemSpawnPosition with default rotation
            Instantiate(currentItem.itemObject, itemSpawnPosition.position, Quaternion.identity);
        }
    }
}