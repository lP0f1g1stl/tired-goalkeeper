using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private BodyTriggerHandler _bodyTrigger;
    [SerializeField] private CoinSpawner _coinSpawner;
    [Space]
    [SerializeField] private PlayerData _playerData;

    public void Init(CoinAnimationData coinAnimationData, LevelData levelData)
    {
        _coinSpawner.Init(coinAnimationData, levelData);
        AddListeners();
    }
    private void AddListeners() 
    {
        _bodyTrigger.OnCollision += ChangeCoins;
    }
    private void ChangeCoins(Projectile projectile) 
    {
        
    }
}
