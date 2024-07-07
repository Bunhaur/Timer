using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI _timerText;
    private Coroutine _timer;
    private bool _isRunning = false;
    private int _currentTime = 0;
    private float _delay = 1;

    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isRunning)
        {
            _isRunning = true;
            StartTimer();
        }
        else if (Input.GetMouseButtonDown(0) && _isRunning)
        {
            _isRunning = false;
            StopCoroutine(_timer);
        }
    }

    private void StartTimer()
    {
        _timer = StartCoroutine(TimerWork(_delay));
    }

    private IEnumerator TimerWork(float delay)
    {
        while (true)
        {
            _timerText.text = _currentTime.ToString();
            _currentTime++;
            yield return new WaitForSeconds(delay);
        }
    }
}
