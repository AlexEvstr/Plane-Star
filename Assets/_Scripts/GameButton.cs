using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickBtnSound;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _heartSound;

    public static bool CanVibration;

    private void Start()
    {
        Time.timeScale = 1;

        _audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("vibro", 1) == 1) CanVibration = true;
        else CanVibration = false;
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

    public void ClickBehavior()
    {
        _audioSource.PlayOneShot(_clickBtnSound);
        if (CanVibration) Vibration.VibratePop();
    }

    public void PlayCoinSound()
    {
        _audioSource.PlayOneShot(_coinSound);
        if (CanVibration) Vibration.VibratePeek();
    }

    public void PlayExplosionSound()
    {
        _audioSource.PlayOneShot(_explosionSound);
        if (CanVibration) Vibration.VibratePeek();
    }

    public void PlayGameoverSound()
    {
        _audioSource.PlayOneShot(_gameOverSound);
        if (CanVibration) Vibration.Vibrate();
    }

    public void PlayHeartSound()
    {
        _audioSource.PlayOneShot(_heartSound);
        if (CanVibration) Vibration.VibratePeek();
    }
}