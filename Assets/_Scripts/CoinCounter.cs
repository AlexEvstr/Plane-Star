using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TMP_Text coinText;
    private int coinCount;

    void Start()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = coinCount.ToString() + "x";
    }
}