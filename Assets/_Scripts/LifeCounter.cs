using UnityEngine;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    public TMP_Text lifeText;
    private int lives;
    private const int maxLives = 4;

    void Start()
    {
        lives = maxLives;
        UpdateLifeText();
    }

    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLifeText();
        }
    }

    public void IncreaseLife()
    {
        if (lives < maxLives)
        {
            lives++;
            UpdateLifeText();
        }
    }

    private void UpdateLifeText()
    {
        lifeText.text = "x" + lives.ToString();
    }
}