using UnityEngine;

public class OnBoardPanel : MonoBehaviour
{
    [SerializeField] private GameObject _onBoard_1;
    [SerializeField] private GameObject _onBoard_2;
    [SerializeField] private GameObject _onBoard_3;
    [SerializeField] private GameObject _onBoard_4;

    private void Start()
    {
        string enter = PlayerPrefs.GetString("Enter", "");
        if (enter == "") _onBoard_1.SetActive(true);
    }

    public void GoToSectond()
    {
        _onBoard_1.SetActive(false);
        _onBoard_2.SetActive(true);
    }

    public void GoToThird()
    {
        _onBoard_2.SetActive(false);
        _onBoard_3.SetActive(true);
    }

    public void GoToFourth()
    {
        _onBoard_3.SetActive(false);
        _onBoard_4.SetActive(true);
    }

    public void GoToGame()
    {
        _onBoard_4.SetActive(false);
        PlayerPrefs.SetString("Enter", "yes");
    }
}