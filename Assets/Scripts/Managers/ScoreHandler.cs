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

    private LevelData _levelData;

    private bool _isStarted;

    public event Action OnWin;

    private void AddListeners()
    {
        _gateTrigger.OnGoal += ChangeScore;
        _bodyTrigger.OnCollision += ChangeScore;
    }

    public void Init(LevelData levelData)
    {
        _levelData = levelData;
        AddListeners();
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
        if (_isStarted)
        {
            _currentScore += points;
        }
        if (_currentScore < 0)
        {
            _currentScore = 0;
        }
        _progressBar.ChangeProgressBar(_currentScore, _levelData.MaxScore);
        CheckScore();
    }
    private void CheckScore() 
    {
        if(_currentScore >= _levelData.MaxScore) 
        {
            OnWin?.Invoke();
        }
    }
}
