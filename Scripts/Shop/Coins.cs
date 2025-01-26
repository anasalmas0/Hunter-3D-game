using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{        private static Coins instance;

    public static Coins Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("Coins");
                instance = obj.AddComponent<Coins>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

    private Text coinText; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        PlayerPrefs.SetInt("Coins", currentCoins + amount);
        PlayerPrefs.Save();
        UpdateCoinText();
    }

    public void SetCoinText(Text text)
    {
        coinText = text;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            int currentCoins = PlayerPrefs.GetInt("Coins", 0);
            coinText.text =  currentCoins.ToString();
        }
    }
}
