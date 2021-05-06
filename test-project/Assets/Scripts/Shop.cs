using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    private const int items_count = 30;
    private const int count_range = 10;
    private const int price_range = 500000;
    // Items in shop
    private static List<GameObject> ItemsInShop = new List<GameObject>();
    // Prefab for item from shop
    [SerializeField]
    private GameObject ShopItemPrefab;
    // Window for content from shop
    [SerializeField]
    private GameObject ShopContent;
    // Button for close shop
    [SerializeField]
    private Button CloseShop;
    // Main menu
    [SerializeField]
    private GameObject MainMenu;
    // Normalized scale for new item from shop
    private Vector3 NormalizedScale = new Vector3(1, 1, 1);
    // Fill in shop 
    private void FillInShop(){
        for (int i = 0; i < items_count; i++){
            GameObject newShopItem = Instantiate(ShopItemPrefab, ShopContent.transform);
            newShopItem.transform.localScale = NormalizedScale;
            newShopItem.GetComponent<ShopItem>().SetValues((Animals)i, Random.Range(0, count_range), Random.Range(1, price_range));
            ItemsInShop.Add(newShopItem);
        }
    }
    private void Start(){
        FillInShop();
        CloseShop.onClick.AddListener(CloseShopClick);
    }
    // Buton for close shop
    private void CloseShopClick(){
        MainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
