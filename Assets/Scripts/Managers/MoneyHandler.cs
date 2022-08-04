using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private BodyTriggerHandler _bodyTrigger;
    [SerializeField] private CoinSpawner _coinSpawner;
    [Space]
    [SerializeField] private MoneyUI _moneyUI;
    [Space]
    [SerializeField] private PlayerData _playerData;

    private int _coinPoints;
    private CoinAnimation[] _coins;

    public void Init(CoinAnimationData coinAnimationData, LevelData levelData)
    {
        _coinSpawner.Init(coinAnimationData, levelData);
        _coinPoints = levelData.BallCannonData.ProjectilesData[(int)ProjectileType.Coin].Projectile.Points;
        _coins = _coinSpawner.Coins;
        AddListeners();
    }
    private void AddListeners() 
    {
        _bodyTrigger.OnCoinCollision += SpawnCoin;
        for (int i = 0; i < _coins.Length; i++)
        {
            _coins[i].OnAnimationComplete += ChangeCoins;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < _coins.Length; i++)
        {
            _coins[i].OnAnimationComplete -= ChangeCoins;
        }
    }
    private void SpawnCoin() 
    {
        _coinSpawner.ShowCoin();
    }

    private void ChangeCoins() 
    {
        _playerData.Coins += _coinPoints;
        _moneyUI.ChangeText(_playerData.Coins.ToString());
    }
}
