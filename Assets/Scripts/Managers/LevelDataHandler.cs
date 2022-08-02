using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    [Header("Controllers and Handlers")]
    [SerializeField] private CannonsController _cannonsController;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private TimerHandler _timerHandler;
    [Space]
    [SerializeField] private EventHandler _eventHandler;
    [Header("LevelData")]
    [SerializeField] private LevelData _levelData;

    private void Awake()
    {
        _cannonsController.Init(_levelData.BallCannonData);
        _scoreHandler.Init(_levelData.MaxScore);
        _timerHandler.Init(_levelData.LevelMaxTime);

        _cannonsController.StartShooting();
        _scoreHandler.StartScoreCounting();
        _timerHandler.StartTimer();
    }
}
