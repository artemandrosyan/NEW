using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour {   
    [SerializeField] 
    private Text CoinsText;
    public static int PlayerCoins;
    private const int coins_count = 9999999;
    private const string K = "K";
    private const string COMMA = ",";
    private const string M = "M";
     
    private void Start(){
        PlayerCoins = Random.Range(1, coins_count);
    }
    // Normalizer for coins count
    private string Normalize(int coinsValue){
        string temp = coinsValue.ToString();
        switch (temp.Length){
            case 7:
                temp = temp.Substring(0, 1) + COMMA + temp.Substring(1, 2) + M;
                break;
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

    private void Update(){
         CoinsText.text = Normalize(PlayerCoins);
    }
    
}
