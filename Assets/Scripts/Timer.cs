using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeForSecond;

    private float _timeLeft;

    [SerializeField] private TextMeshProUGUI _timerText;

    private void Start()
    {
        _timeLeft = _timeForSecond;
        StartCoroutine(GameEndTimer());
    }

    private IEnumerator GameEndTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;

            UpdateTimeText();

            yield return null; 
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            _timeLeft = 0;
        }

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);

        _timerText.text = string.Format($"{minutes}:{seconds}");
    }
}
