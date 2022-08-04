using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallCannon : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _barrelHolder;
    
    private float _turnDuration;

    private Tween _shooting;

    public void Init(float turnDuration)
    {
        _turnDuration = turnDuration;
    }
    public void StopShooting() 
    {
        _shooting?.Kill();
    }
    public void Shoot(Projectile projectile, Vector3 targetPoint, float force) 
    {
        _shooting = _barrelHolder.DOLookAt(targetPoint, _turnDuration)
            .OnComplete(() => 
            {
                projectile.transform.position = _spawnPoint.position;
                projectile.transform.rotation = _barrelHolder.rotation;
                projectile.gameObject.SetActive(true);
                projectile.SetSpeed(Vector3.forward * force);
                });
    }
}
