using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventoryController : MonoBehaviour
{
    [SerializeField] private UIShop uiShop;
    public int shopSize = 3;

    private void Start()
    {
        uiShop.InitializeShopUI(shopSize);
    }
    public void OpenShop()
    {
        if(uiShop.isActiveAndEnabled == false)
        {
            uiShop.Show();
        }
        else
        {
            uiShop.Hide();
        }
    }

}
