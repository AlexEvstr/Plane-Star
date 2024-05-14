using UnityEngine;
using TMPro;
using System.Collections;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameButton _gameButton;

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

            if (lives == 0)
            {
                StartCoroutine(ShowLosePanel());
            }
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

    private IEnumerator ShowLosePanel()
    {
        yield return new WaitForSeconds(0.5f);
        _gameButton.PlayGameoverSound();
        _losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}