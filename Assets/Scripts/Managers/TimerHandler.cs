using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private TimerUI _timerUI;

    private int _currentTime;
    private int _levelMaxTime;

    private int _minutes;
    private int _seconds;

    private bool _isStarted;

    private Coroutine _timer;

    public event Action OnTimerEnd;

    public void Init(int maxLevelTime)
    {
        _levelMaxTime = maxLevelTime;
    }
    public void StartTimer() 
    {
        IntToTime();
        _timerUI.ChangeTimerText(_minutes, _seconds);
        if (_timer != null) 
        {
            StopCoroutine(_timer);
        }
        _isStarted = true;
        _timer = StartCoroutine(Timer());
    }
    public void StopTimer() 
    {
        _isStarted = false;
    }
    private IEnumerator Timer()
    {
        while (_isStarted)
        {
            yield return new WaitForSeconds(1f);
            _currentTime++;
            IntToTime();
            _timerUI.ChangeTimerText(_minutes, _seconds);
            if(_currentTime >= _levelMaxTime) 
            {
                OnTimerEnd?.Invoke();
            }
        }
    }
    private void IntToTime() 
    {
        _minutes = (_levelMaxTime - _currentTime) / 60;
        _seconds = (_levelMaxTime - _currentTime) % 60;
    }
}
