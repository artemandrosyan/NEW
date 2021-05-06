using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class WareHouseItem : MonoBehaviour {
    [SerializeField]
    private Text Title;
    [SerializeField]
    private Text Count;
    [SerializeField]
    private Image ItemImage;
    [SerializeField]
    private SpriteAtlas Atlas;
    // Setter and getter for warehouse item count
    public int _Count{
        get {return int.Parse(Count.text);
        }
        set {Count.text = value.ToString(); 
        }
    }
    // Set values to warehouse item
    public void SetValues(Animals title, int count){
        Title.text = title.ToString();
        Count.text = count.ToString();
        ItemImage.sprite = Atlas.GetSprite(Title.text);
    }

    
}
