using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCannonData", menuName ="ObjectsData/CannonData")]
public class BallCanonData : ScriptableObject
{
    [SerializeField] private float _defaultFireRateRPM;
    [Space]
    [SerializeField] private Projectile[] _projectiles;

    public float DefaultDireRate => _defaultFireRateRPM;
    public Projectile[] Projectiles => _projectiles;
}
