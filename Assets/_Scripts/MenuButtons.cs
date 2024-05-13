using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsPanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void OpenSettings()
    {
        _mainMenu.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
