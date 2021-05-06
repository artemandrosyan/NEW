using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WareHouse :MonoBehaviour, IAnimalBuyEvent {
    // List for items in warehouse
    public static List<GameObject> ItemsInWareHouse = new List<GameObject>();
    // List for animals type in warehouse
    public static List<Animals> AnimalsInWareHouse = new List<Animals>();
    // Prefab for warehouse item
    [SerializeField]
    private GameObject WareHouseItemPrefab;
    // Content window for warehouse items
    [SerializeField]
    private GameObject WareHouseContent;
    // Main menu window 
    [SerializeField]
    private GameObject MainMenu;
    // Button for close wareouse
    [SerializeField]
    private Button CloseWareHouse;
    // Normalized scale for item in warehouse
    private Vector3 NormalizedScale = new Vector3(1, 1, 1);

    private void Start() {
        CloseWareHouse.onClick.AddListener(CloseShopClick);
    }
    // Add new item in warehouse or change count one of them
    private void AddWareHouseItem(Animals animal) {
        if (AnimalsInWareHouse.IndexOf(animal) == -1) {
            AnimalsInWareHouse.Add(animal);
            GameObject newWareHouseItem = Instantiate(WareHouseItemPrefab);
            newWareHouseItem.GetComponent<WareHouseItem>().SetValues(animal,1);
            ItemsInWareHouse.Add(newWareHouseItem);
        }
        else {
            ItemsInWareHouse[AnimalsInWareHouse.IndexOf(animal)].GetComponent<WareHouseItem>()._Count++;
        }
    }
    // or event after buy animal
    public void OnAnimalBuy(Animals animal) {
        AddWareHouseItem(animal);
    }
    // Sho items from warehouse in window
    public void ShowItemsInWareHouse() {
        foreach (GameObject Item in ItemsInWareHouse) {
            Item.transform.SetParent(WareHouseContent.transform);
            Item.transform.localScale = NormalizedScale;
        }
    }
    // Close warehouse
    private void CloseShopClick() {
        MainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
