using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
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
    public Transform itemSpawnPostiton;
    public GameObject buttonPrefab;
    public Transform shopPandel;
    public Button closeShopButton;

    private void Start()
    {
        OpenShop();
    }


    public void OpenShop()
    {
        for(int i = 0; 1 < shopItems.Length; i++)
        {
            GameObject shopButton = Instantiate(buttonPrefab, shopPandel);
            shopButton.GetComponent<ShopItemBehavior>().SetShopItem(shopItems[i], this);
        }

        shopPandel.gameObject.SetActive(true);
    }

    public void CloseShop()
    {

    }


    public void BuyShopItem(Item currentItem)
    {
     
        if(GameController.instance.BoltAmount >= currentItem.itemCost)
        {
            GameController.instance.ChangeBoltAmount(-currentItem.itemCost);
            //Create Object at ItemSpawnPostiion with default rotation.
            Instantiate(currentItem.itemObject, itemSpawnPostiton.position, Quaternion.identity);
        }
    }

}
