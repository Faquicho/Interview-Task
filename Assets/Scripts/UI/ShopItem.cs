using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image outfitImage;
    [SerializeField] private TMP_Text outfitPrice;
    [SerializeField] private Image borderImage;

    public event Action<ShopItem> OnItemClicked;

    private bool empty = true;

    private void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        this.outfitImage.gameObject.SetActive(false);
        empty = true;
    }

    public void Deselect() 
    {
        borderImage.enabled = false;
    }

    public void SetData(Sprite sprite, int price)
    {
        this.outfitImage.gameObject.SetActive(true);
        this.outfitImage.sprite = sprite;
        this.outfitPrice.text = price + "";
        empty = false;
    }

    public Sprite GetOutfitSprite() { return this.outfitImage.sprite; }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void OnPointerClick(BaseEventData data) 
    {
        //if (empty) { return; }
        PointerEventData pointerdata = (PointerEventData)data;
        if(pointerdata.button == PointerEventData.InputButton.Left) 
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
