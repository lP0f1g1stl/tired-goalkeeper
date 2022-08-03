using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCoinAnimationData", menuName = "UI/CoinAnimationData")]
public class CoinAnimationData : ScriptableObject
{
    [SerializeField] private CoinAnimation _coinPrefab;
    [Space]
    [SerializeField] private float _coinFlightDuration;

    public CoinAnimation CoinPrefab => _coinPrefab;
    public float CoinFlightDuration => _coinFlightDuration;
}
