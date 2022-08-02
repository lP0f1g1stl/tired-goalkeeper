using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private CannonsController _cannonsController;
    private ScoreHandler _scoreHandler;
    private TimerHandler _timerHandler;

    public void Init(CannonsController cannonsController, ScoreHandler scoreHandler, TimerHandler timerHandler)
    {
        _cannonsController = cannonsController;
        _scoreHandler = scoreHandler;
        _timerHandler = timerHandler;
        OnInit();
    }

    private void OnInit()
    {
        _timerHandler.OnTimerEnd += _cannonsController.StopShooting;
        _timerHandler.OnTimerEnd += _timerHandler.StopTimer;
        _timerHandler.OnTimerEnd += _scoreHandler.StartScoreCounting;

        _scoreHandler.OnWin += _cannonsController.StopShooting;
        _scoreHandler.OnWin += _timerHandler.StopTimer;
        _scoreHandler.OnWin += _scoreHandler.StopScoreCounting;
    }
}
