using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemBehavior : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemText;
    public Button buyButton;
    
    public void SetShopItem(ShopBehavior.Item item, ShopBehavior shop)
    {
        TogglePanelElements(true);
        itemIcon.sprite = item.itemIcon;
        itemText.text = item.itemName + " - $" + item.itemCost;
        buyButton.onClick.RemoveAllListeners();

        buyButton.onClick.AddListener(() => shop.BuyShopItem(item));
        buyButton.onClick.AddListener(() => buyButton.interactable = GameController.instance.BoltAmount >= item.itemCost);

        buyButton.interactable = GameController.instance.BoltAmount >= item.itemCost;
    }

    public void TogglePanelElements(bool state)
    {
        itemIcon.gameObject.SetActive(state);
        itemText.gameObject.SetActive(state);
        buyButton.gameObject.SetActive(state);
    }
}
