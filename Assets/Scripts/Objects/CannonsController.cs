using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsController : MonoBehaviour
{
    [SerializeField] private BallCannon[] _cannons;
    [SerializeField] private Transform _projectileHolder;
    [Space]
    [SerializeField] private ProjectileSpawner[] _projectileSpawners;
    [Space]
    [SerializeField] private BallCannonData _cannonData;
    [Space]
    [SerializeField] private Transform[] _shootingSectorPoints;

    private bool _isStarted;

    private void Awake()
    {
        for (int i = 0; i < _cannons.Length; i++)
        {
            _projectileSpawners[i].Init(_cannonData.Projectiles[i]);
        }
        for(int i= 0; i<_cannons.Length; i++) 
        {
            _cannons[i].Init(_cannonData.MinShootingDelay);
        }
    }
    private void Start()
    {
        _isStarted = true;
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting() 
    {
        while (_isStarted)
        {
            float delay = Random.Range(_cannonData.MinShootingDelay, _cannonData.MaxShootingDelay);
            int cannonID = Random.Range(0, _cannons.Length);
            yield return new WaitForSeconds(delay);
            _cannons[cannonID].Shoot(GetProjectile() , CalculateTargetPoint(), _cannonData.ProjectileImpulse);
        }
    }
    private Projectile GetProjectile() 
    {
        int rand = Random.Range(0, 100);
        Projectile projetile = rand > _cannonData.BombPercent ? _projectileSpawners[0].TryGetProjectile() : _projectileSpawners[1].TryGetProjectile();
        return projetile;
    }
    private Vector3 CalculateTargetPoint() 
    {
        float x = Random.Range(_shootingSectorPoints[0].position.x, _shootingSectorPoints[1].position.x);
        float y= Random.Range(_shootingSectorPoints[0].position.y, _shootingSectorPoints[1].position.y);
        float z= Random.Range(_shootingSectorPoints[0].position.z, _shootingSectorPoints[1].position.z);
        return new Vector3(x, y, z);
    }
}
