using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI

public class ShopBehavior : MonoBehaviour
{
    [Serializable]
    public struct Item
    {
        public string itemName;
        public int itemCost;
        public GameObject itemObject;
    }

    public Item[] shopItems;
    public Transform itemSpawnPostiton;
    public GameObject buttonPrefab;
    public Transform shopPandel;
    public Button closeShopButton;


    public void OpenShop()
    {
        for(int i = 0; 1 < shopItems.Length; i++)
        {
            GameObject shopButton = Instantiate(buttonPrefab, shopPandel);
            shopButton.GetComponent<Button>().onClick.RemoveAllListeners();
            shopButton.GetComponent<Button>().onClick.AddListener(() => BuyShopItem(i));
        }

        shopPandel.gameObject.SetActive(true);
    }

    public void CloseShop()
    {

    }


    public void BuyShopItem(int itemIndex)
    {
        Item currentItem = shopItems[itemIndex];
        if(GameController.instance.BoltAmount >= currentItem.itemCost)
        {
            GameController.instance.ChangeBoltAmount(-currentItem.itemCost);
            //Create Object at ItemSpawnPostiion with default rotation.
            Instantiate(currentItem.itemObject, itemSpawnPostiton.position, Quaternion.identity);
        }
    }

}
