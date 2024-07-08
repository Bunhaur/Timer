using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Coroutine _timer;
    private int _currentTime = 0;
    private float _delay = 1;
   
    public Action<int> TimeIsChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _timer == null)
        {
            StartTimer();
        }
        else if (Input.GetMouseButtonDown(0) && _timer != null)
        {
            StopCoroutine(_timer);
            _timer = null;
        }
    }

    private void StartTimer()
    {
        _timer = StartCoroutine(TimerWork(_delay));
    }

    private IEnumerator TimerWork(float delay)
    {
        var wait = new WaitForSeconds(delay);
    
        while (true)
        {
            TimeIsChanged?.Invoke(_currentTime);
            yield return wait;
            _currentTime++;
        }
    }
}
