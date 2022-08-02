using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyTriggerHandler : MonoBehaviour
{
    [SerializeField] private BodyTrigger[] _bodyTrigger;

    public event Action<int> OnCollision;

    private void OnEnable()
    {
        foreach(BodyTrigger bodyTrigger in _bodyTrigger) 
        {
            bodyTrigger.OnBallCollision += OnCollision;
        }
    }
    private void OnDisable()
    {
        foreach (BodyTrigger bodyTrigger in _bodyTrigger)
        {
            bodyTrigger.OnBallCollision -= OnCollision;
        }
    }
}
