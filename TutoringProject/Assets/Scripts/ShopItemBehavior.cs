using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemBehavior : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public Image itemIcon;
    public Button buyButton;

    public void SetShopItem(ShopBehavior.Item item, ShopBehavior shop)
    {
        itemIcon.sprite = item.itemIcon;
        itemText.text = item.itemName + " - $" + item.itemCost;
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() => shop.BuyShopItem(item));

        buyButton.interactable = GameController.instance.BoltAmount >= item.itemCost;
    }
    public void TogglePanelElements(bool state)
    {
        itemIcon.gameObject.SetActive(state);
        itemText.gameObject.SetActive(state);
        buyButton.gameObject.SetActive(state);
    }
   
   

}
