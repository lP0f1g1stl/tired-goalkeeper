using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCannonData", menuName ="ObjectsData/CannonData")]
public class BallCannonData : ScriptableObject
{
    [SerializeField] private float _minShootingDelay;
    [SerializeField] private float _maxShootingDelay;
    [Space]
    [SerializeField] private float _projectileImpulse;
    [Space]
    [SerializeField] private Projectile[] _projectiles;
    [Space]
    [Range(0, 100)]
    [SerializeField] private int _bombPercent;

    public float MinShootingDelay => _minShootingDelay;
    public float MaxShootingDelay => _maxShootingDelay;
    public float ProjectileImpulse => _projectileImpulse;
    public Projectile[] Projectiles => _projectiles;
    public int BombPercent => _bombPercent;
}
