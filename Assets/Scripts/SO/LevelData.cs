using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "LevelsData/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private BallCannonData _cannonData;
    [Space]
    [SerializeField] private int _maxScore;
    [Space]
    [SerializeField] private float _minCoinShowingDelay;
    [SerializeField] private float _maxCoinShowingDelay;
    [Space]
    [SerializeField] private int _levelMaxTime;

    public BallCannonData BallCannonData => _cannonData;
    public int MaxScore => _maxScore;
    public float MinCoinShowingDelay => _minCoinShowingDelay;
    public float MaxCoinShowingDelay => _maxCoinShowingDelay;
    public int LevelMaxTime => _levelMaxTime;
}
