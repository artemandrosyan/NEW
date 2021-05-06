using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour {
    [SerializeField]
    private Button ShopButton;
    [SerializeField]
    private Button WareHouseButton;
    [SerializeField]
    private GameObject ShopCanvas;
    [SerializeField]
    private GameObject WareHouseCanvas;
    [SerializeField]
    private GameObject MenuUI;
    // Object for cash 
    private WareHouse WH;

    private void Start(){
        WH = WareHouseCanvas.GetComponentInChildren<WareHouse>();
        ShopButton.onClick.AddListener(OnShopClick);
        WareHouseButton.onClick.AddListener(OnWareHouseClick);
    }
    // Handler ShopButton
    private void OnShopClick(){
        ShopCanvas.SetActive(true);
        MenuUI.gameObject.SetActive(false);
    }
    // Handler WareHouseButton
    private void OnWareHouseClick(){
        WareHouseCanvas.SetActive(true);
        WH.ShowItemsInWareHouse();
        MenuUI.gameObject.SetActive(false);
    }

}
