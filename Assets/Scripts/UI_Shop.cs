using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using CodeMonkey.Utils;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;
    private Button shopItemButton;

    private void Awake(){
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplet");
        //shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start(){
        CreateItemButton(Items.ItemType.sword_Sway, Items.GetSprite(Items.ItemType.sword_Sway), "SWAY SWORD", Items.GetCost(Items.ItemType.sword_Sway), 0);
        CreateItemButton(Items.ItemType.sword_Champ, Items.GetSprite(Items.ItemType.sword_Champ), "CHAMP SWORD", Items.GetCost(Items.ItemType.sword_Champ), 1);
        CreateItemButton(Items.ItemType.shield_Crude, Items.GetSprite(Items.ItemType.shield_Crude), "SHIELD CRUDE", Items.GetCost(Items.ItemType.shield_Crude), 2);
        CreateItemButton(Items.ItemType.shield_Nail, Items.GetSprite(Items.ItemType.shield_Nail), "SHIELD NAIL", Items.GetCost(Items.ItemType.shield_Nail), 3);
        CreateItemButton(Items.ItemType.shield_Champ, Items.GetSprite(Items.ItemType.shield_Champ), "SHIELD CHAMP", Items.GetCost(Items.ItemType.shield_Champ), 4);

        Hide();
    }

    private void CreateItemButton(Items.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex){
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopHeight = 80f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopHeight * positionIndex);

        shopItemTransform.Find("ItemText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("Cost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {  
            //Clicked on shop item button
            Debug.Log("Button Clicked");
            TryBuyItem(itemType, itemCost, itemName);
        };

        // shopItemButton = shopItemTransform.Find("TemplateButton").GetComponent<Button>();
        // Debug.Log(shopItemButton + "Button");
        // //shopItemButton.onClick.AddListener(() => TryBuyItem(itemType));
        // shopItemButton.onClick.AddListener(printthis);
        
    }
    

    public void TryBuyItem(Items.ItemType itemType, int itemCost, string itemName){
        Debug.Log("Button Clicked");
        // shopCustomer.BoughtItem(itemType);
        //shopCustomer.TryToSpendMoney(itemCost);
        if(shopCustomer.TryToSpendMoney(itemCost)){
            shopCustomer.BoughtItem(itemType, itemName);
        }
    }

    public void Show(IShopCustomer shopCustomer){
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }
    // public void printthis(){
    //     Debug.Log("Print this");
    // }
}
