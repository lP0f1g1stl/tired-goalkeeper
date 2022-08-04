using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;

    private LevelData _levelData;
    private CoinAnimationData _coinData;
    private CoinAnimation[] _coins;
    private int _currentCoin;

    public CoinAnimation[] Coins => _coins; 

    public void Init(CoinAnimationData coinData, LevelData levelData) 
    {
        _levelData = levelData;
        _coinData = coinData;
        CreateUICoins();
    }

    public void CreateUICoins()
    {
        int coinsLength = Mathf.CeilToInt(_coinData.CoinFlightDuration / _levelData.BallCannonData.MinShootingDelay);
        _coins = new CoinAnimation[coinsLength];
        for (int i = 0; i < _coins.Length; i++)
        {
            _coins[i] = Instantiate(_coinData.CoinPrefab, transform);
        }
    }
    public void ShowCoin()
    {
        Vector3 startPos = Camera.main.WorldToScreenPoint(_startPos.position);
        _coins[_currentCoin].AnimateCoin(startPos, _endPos, _coinData.CoinFlightDuration);
        _currentCoin++;
        if (_currentCoin >= _coins.Length)
        {
            _currentCoin = 0;
        }
    }

}
