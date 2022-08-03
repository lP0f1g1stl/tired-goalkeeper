using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreHandler : MonoBehaviour
{
    [Header("Triggers")]
    [SerializeField] private GateTrigger _gateTrigger;
    [SerializeField] private BodyTriggerHandler _bodyTrigger;
    [Space]
    [SerializeField] private ProgressBar _progressBar;

    private int _currentScore;
    private int _maxScore;

    private bool _isStarted;

    public event Action OnWin;

    private void OnEnable()
    {
        _gateTrigger.OnGoal += ChangeScore;
        _bodyTrigger.OnBallCollision += ChangeScore;
    }

    public void Init(int maxScore)
    {
        _maxScore = maxScore;
    }
    public void StartScoreCounting()
    {
        _isStarted = true;
    }
    public void StopScoreCounting()
    {
        _isStarted = false;
    }
    public void ChangeScore(int points) 
    {
        Debug.Log(points);
        if (_isStarted)
        {
            _currentScore += points;
            if (_currentScore < 0) 
            { 
                _currentScore = 0; 
            }
            _progressBar.ChangeProgressBar(_currentScore, _maxScore);
            CheckScore();
        }
    }
    private void CheckScore() 
    {
        if(_currentScore >= _maxScore) 
        {
            OnWin?.Invoke();
        }
    }
}
