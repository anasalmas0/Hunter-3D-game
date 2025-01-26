using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinManager : MonoBehaviour
{
    
     public Text coinText; 
    private void Start()
    {
        Coins.Instance.SetCoinText(coinText);
    }


}
