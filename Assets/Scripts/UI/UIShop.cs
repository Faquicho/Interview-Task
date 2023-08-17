using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] ShopItem shopItemPrefab;
    [SerializeField] RectTransform shopPanel;
    private PlayerController playerController;

    List<ShopItem> shopItemsList = new List<ShopItem>();

    public Sprite sprite, sprite2, sprite3;
    public int price, price2, price3;

    public void InitializeShopUI(int shopSize)
    {
        for(int i = 0; i < shopSize; i++) 
        {
            ShopItem shopItem = Instantiate(shopItemPrefab, Vector3.zero, Quaternion.identity);
            shopItem.transform.SetParent(shopPanel);
            shopItemsList.Add(shopItem);

            shopItem.OnItemClicked += HandleItemSelection;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);

        shopItemsList[0].SetData(sprite, price);
        shopItemsList[1].SetData(sprite2, price2);
        shopItemsList[2].SetData(sprite3, price3);
    }

    public void Hide() 
    {
        gameObject.SetActive(false);
    }

    private void HandleItemSelection(ShopItem obj)
    {
        int index = shopItemsList.IndexOf(obj);
        ResetSelection();
        shopItemsList[index].Select();
        EquipOutfit(shopItemsList[index].GetOutfitSprite(), playerController);
    }

    private void ResetSelection()
    {
        foreach (ShopItem item in shopItemsList)
        {
            item.Deselect();
        }
    }

    public void EquipOutfit(Sprite newItemSprite, PlayerController playerController)
    {
        playerController.SetPlayerSprite(newItemSprite);
    }
}
