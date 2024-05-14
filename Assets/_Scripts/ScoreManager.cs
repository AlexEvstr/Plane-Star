using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    private float _timeCounter;

    private void Start()
    {
        _timeCounter = 0.0f;
    }

    private void Update()
    {
        _timeCounter += Time.deltaTime;
        _score.text = _timeCounter.ToString("F1") + "x";
    }
}