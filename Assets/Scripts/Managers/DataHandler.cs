using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [Header("Controllers and Handlers")]
    [SerializeField] private CannonsController _cannonsController;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private TimerHandler _timerHandler;
    [SerializeField] private EndScreenHandler _endScreenHandler;
    [SerializeField] private MoneyHandler _moneyHandler;
    [Space]
    [SerializeField] private EventHandler _eventHandler;
    [Header("LevelData")]
    [SerializeField] private LevelData _levelData;
    [SerializeField] private CoinAnimationData _coinAnimationData;

    private void Awake()
    {
        _cannonsController.Init(_levelData.BallCannonData);
        _scoreHandler.Init(_levelData);
        _timerHandler.Init(_levelData.LevelMaxTime);
        _eventHandler.Init(_cannonsController, _scoreHandler, _timerHandler, _endScreenHandler);
        _moneyHandler.Init(_coinAnimationData, _levelData);

        _cannonsController.StartShooting();
        _scoreHandler.StartScoreCounting();
        _timerHandler.StartTimer();
    }
}
