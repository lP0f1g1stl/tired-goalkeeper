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
    [SerializeField] private Transform[] _shootingSectorPoints;

    private BallCannonData _cannonData;

    private Coroutine _shooting;

    private bool _isStarted;

    public void Init(BallCannonData cannonData)
    {
        _cannonData = cannonData;
        for (int i = 0; i < _projectileSpawners.Length; i++)
        {
            _projectileSpawners[i].Init(_cannonData.ProjectilesData[i].Projectile);
        }
        for(int i= 0; i<_cannons.Length; i++) 
        {
            _cannons[i].Init(_cannonData.MinShootingDelay);
        }
    }
    public void StartShooting()
    {
        if (_shooting != null)
        {
            StopCoroutine(_shooting);
        }
        _isStarted = true;
        _shooting = StartCoroutine(Shooting());
    }
    public void StopShooting() 
    {
        _isStarted = false;
        for (int i = 0; i < _cannons.Length; i++)
        {
            _cannons[i].StopShooting();
        }
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
        for (int i = 0; i< _cannonData.ProjectilesData.Length; i++) 
        {
            if (_cannonData.ProjectilesData[i].MaxNum > rand) 
            {
                return _projectileSpawners[i].TryGetProjectile();
            }
        }
        return _projectileSpawners[(int)ProjectileType.Ball].TryGetProjectile();
    }
    private Vector3 CalculateTargetPoint() 
    {
        float x = Random.Range(_shootingSectorPoints[0].position.x, _shootingSectorPoints[1].position.x);
        float y = Random.Range(_shootingSectorPoints[0].position.y, _shootingSectorPoints[1].position.y);
        float z = Random.Range(_shootingSectorPoints[0].position.z, _shootingSectorPoints[1].position.z);
        return new Vector3(x, y, z);
    }
}
