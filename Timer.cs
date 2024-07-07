using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action<int> TimeIsChanged;
    private Coroutine _timer;
    private int _currentTime = 0;
    private bool _isRunning = false;
    private float _delay = 1;

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
            TimeIsChanged?.Invoke(_currentTime);
            yield return new WaitForSeconds(delay);
            _currentTime++;
        }
    }
}
