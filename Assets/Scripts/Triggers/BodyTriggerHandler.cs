using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyTriggerHandler : MonoBehaviour
{
    [SerializeField] private BodyTrigger[] _bodyTrigger;

    public event Action<int> OnCollision;
    public event Action OnCoinCollision;

    private void OnEnable()
    {
        foreach(BodyTrigger bodyTrigger in _bodyTrigger) 
        {
            bodyTrigger.OnCollision += ChangeCollidedObjectState;
        }
    }
    private void OnDisable()
    {
        foreach (BodyTrigger bodyTrigger in _bodyTrigger)
        {
            bodyTrigger.OnCollision -= ChangeCollidedObjectState;
        }
    }
    private void ChangeCollidedObjectState(Projectile projectile) 
    {
        switch (projectile.ProjectileType)
        {
            case ProjectileType.Ball:
                OnCollision?.Invoke(projectile.Points);
                break;
            case ProjectileType.Bomb:
                projectile.gameObject.SetActive(false);
                OnCollision?.Invoke(projectile.Points);
                break;
            case ProjectileType.Coin:
                projectile.gameObject.SetActive(false);
                OnCoinCollision?.Invoke();
                break;
        }
    }
}
