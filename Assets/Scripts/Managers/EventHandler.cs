using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private CannonsController _cannonsController;
    private ScoreHandler _scoreHandler;
    private TimerHandler _timerHandler;
    private EndScreenHandler _endScreenHandler;

    public void Init(CannonsController cannonsController, ScoreHandler scoreHandler, TimerHandler timerHandler, EndScreenHandler endScreenHandler)
    {
        _cannonsController = cannonsController;
        _scoreHandler = scoreHandler;
        _timerHandler = timerHandler;
        _endScreenHandler = endScreenHandler;
        OnInit();
    }

    private void OnInit()
    {
        _timerHandler.OnTimerEnd += _cannonsController.StopShooting;
        _timerHandler.OnTimerEnd += _timerHandler.StopTimer;
        _timerHandler.OnTimerEnd += _scoreHandler.StopScoreCounting;
        _timerHandler.OnTimerEnd += _endScreenHandler.ShowLoseScreen;

        _scoreHandler.OnWin += _cannonsController.StopShooting;
        _scoreHandler.OnWin += _timerHandler.StopTimer;
        _scoreHandler.OnWin += _scoreHandler.StopScoreCounting;
        _scoreHandler.OnWin += _endScreenHandler.ShowWinScreen;
    }
}
