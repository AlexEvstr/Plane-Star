using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnToGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}