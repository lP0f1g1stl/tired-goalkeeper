using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyTriggerHandler : MonoBehaviour
{
    [SerializeField] private BodyTrigger[] _bodyTrigger;

    public event Action<Projectile> OnCollision;

    private void OnEnable()
    {
        foreach(BodyTrigger bodyTrigger in _bodyTrigger) 
        {
            bodyTrigger.OnCollision += ChangePoints;
        }
    }
    private void OnDisable()
    {
        foreach (BodyTrigger bodyTrigger in _bodyTrigger)
        {
            bodyTrigger.OnCollision -= ChangePoints;
        }
    }
    private void ChangePoints(Projectile projectile) 
    {
        OnCollision?.Invoke(projectile);
    }
}
