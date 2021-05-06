using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
// Animals in shop

public class ShopItem :MonoBehaviour {
    private const string ZERO = "0";
    [SerializeField]
    private Text Title;
    [SerializeField]
    private Text Count;
    [SerializeField]
    private Text Price;
    [SerializeField]
    private Image ItemImage;
    [SerializeField]
    private Button BuyButton;
    [SerializeField]
    private SpriteAtlas Atlas;
    [SerializeField]
    private GameObject WareHouse;
    // Id of animal for event
    private Animals id;
    // Int value for work with coins
    private int priceValue;
    // Int value for work with coins
    private int countAnimals;
    private const string K = "K";
    private const string COMMA = ",";
    private IAnimalBuyEvent AnimEvent;
    // Delegate and event for buy animal
    public delegate void ItemGoWareHouseEvent(Animals sender);
    public event ItemGoWareHouseEvent BuyItemEvent;
    // Message about bought animal
    public void MessageForWareHouse(Animals id) {
        BuyItemEvent += new ItemGoWareHouseEvent(AnimEvent.OnAnimalBuy);
        if (BuyItemEvent != null) {
            BuyItemEvent.Invoke(id);
            BuyItemEvent -= new ItemGoWareHouseEvent(AnimEvent.OnAnimalBuy);
        }
    }
    // Set values for item from shop
    public void SetValues(Animals title, int count, int price) {
        id = title;
        priceValue = price;
        Title.text = title.ToString();
        countAnimals = count;
        Count.text = count.ToString();
        Price.text = Normalize(price);
        ItemImage.sprite = Atlas.GetSprite(Title.text);
    }

    private void Start() {
        BuyButton.onClick.AddListener(BuyButtonClick);
        AnimEvent = WareHouse.GetComponent<IAnimalBuyEvent>();
    }
    // Normalizer for price item shop
    private string Normalize(int coinsValue) {
        string temp = coinsValue.ToString();
        switch (temp.Length) {
            case 6:
            case 5:
            case 4:
                temp = temp.Substring(0, temp.Length - 3) + COMMA + temp.Substring(temp.Length - 3, 1) + K;
                break;
            default:
                break;
        }
        return temp;
    }

    private void BuyButtonClick() {
        if (CoinsController.PlayerCoins >= priceValue && (Count.text != ZERO)) {
            CoinsController.PlayerCoins -= priceValue;
            countAnimals--;
            Count.text = countAnimals.ToString();
            MessageForWareHouse(id);
        }
    }


}

