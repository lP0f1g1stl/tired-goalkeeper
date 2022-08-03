using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyTriggerHandler : MonoBehaviour
{
    [SerializeField] private BodyTrigger[] _bodyTrigger;

    public event Action<int> OnBallCollision;
    public event Action<int> OnCoinCollision;

    private void OnEnable()
    {
        foreach(BodyTrigger bodyTrigger in _bodyTrigger) 
        {
            bodyTrigger.OnBallCollision += ChangePoints;
            bodyTrigger.OnCoinCollision += ChangeCoins;
        }
    }
    private void OnDisable()
    {
        foreach (BodyTrigger bodyTrigger in _bodyTrigger)
        {
            bodyTrigger.OnBallCollision -= ChangePoints;
            bodyTrigger.OnCoinCollision -= ChangeCoins;
        }
    }
    private void ChangePoints(int points) 
    {
        OnBallCollision?.Invoke(points);
    }
    private void ChangeCoins(int points) 
    {
        OnCoinCollision?.Invoke(points);
    }
}
