using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private Projectile _projectile;

    private List<Projectile> _projectiles = new List<Projectile>();

    private int _curProjectile;

    public void Init(Projectile projectile)
    {
        _projectile = projectile;
        CreateProjectile();
    }
    public Projectile TryGetProjectile()
    {
        if (_curProjectile >= _projectiles.Count) _curProjectile = 0;
        Projectile projectile = _projectiles[_curProjectile].gameObject.activeSelf ? CreateProjectile() : _projectiles[_curProjectile];
        _curProjectile++;
        return projectile;
    }
    private Projectile CreateProjectile()
    {
        _projectiles.Add(Instantiate(_projectile, transform));
        _curProjectile = _projectiles.Count - 1;
        _projectiles[_curProjectile].gameObject.SetActive(false);
        return _projectiles[_curProjectile];
    }
}
