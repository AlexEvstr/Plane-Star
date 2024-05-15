using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _tutorialPanel;

    [SerializeField] private GameObject _audioOn;
    [SerializeField] private GameObject _audioOff;
    [SerializeField] private GameObject _vibroOn;
    [SerializeField] private GameObject _vibroOff;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickBtnSound;

    public static bool CanVibration;

    private void Start()
    {
        Time.timeScale = 1;

        Vibration.Init();

        _audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetFloat("audio", 1) == 1) AudioOn();
        else AudioOff();

        if (PlayerPrefs.GetInt("vibro", 1) == 1) VibrationOn();
        else VibrationOff();
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

    public void AudioOff()
    {
        _audioOn.SetActive(false);
        _audioOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("audio", 0);
    }

    public void AudioOn()
    {
        _audioOff.SetActive(false);
        _audioOn.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("audio", 1);
    }

    public void VibrationOff()
    {
        _vibroOn.SetActive(false);
        _vibroOff.SetActive(true);
        CanVibration = false;
        PlayerPrefs.SetInt("vibro", 0);
    }

    public void VibrationOn()
    {
        _vibroOff.SetActive(false);
        _vibroOn.SetActive(true);
        CanVibration = true;
        PlayerPrefs.SetInt("vibro", 1);
    }

    public void CLickBehavior()
    {
        _audioSource.PlayOneShot(_clickBtnSound);
        if (CanVibration) Vibration.VibratePop();
    }

    public void OpenTutorial()
    {
        _tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        _tutorialPanel.SetActive(false);
    }
}