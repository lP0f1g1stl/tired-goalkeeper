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
    [SerializeField] private ProjectileData[] _projectilesData;

    public float MinShootingDelay => _minShootingDelay;
    public float MaxShootingDelay => _maxShootingDelay;
    public float ProjectileImpulse => _projectileImpulse;
    public ProjectileData[] ProjectilesData => _projectilesData;

    private void OnValidate()
    {
        for(int i = 0; i < _projectilesData.Length; i++) 
        {
            if(_projectilesData[i].SpawnPercent != _projectilesData[i].TempPercent) 
            {
                int sum = CalculateSum(i);
                int remainder = 100 - sum;
                if (remainder < 0)
                {
                    _projectilesData[i].SpawnPercent = _projectilesData[i].TempPercent;
                }
                _projectilesData[i].TempPercent = _projectilesData[i].SpawnPercent;
                SetMinMaxNum(i, _projectilesData[i].SpawnPercent);
            }
        }

    }
    private int CalculateSum(int index) 
    {
        int sum = 0;
        for (int i = 0; i < _projectilesData.Length; i++) 
        {
            sum += _projectilesData[i].SpawnPercent;
        }
        return sum;
    }
    private void  SetMinMaxNum(int index, int percent) 
    {
        if(index == 0) 
        {
            _projectilesData[index].MinNum = 0;
        }
        else 
        {
            _projectilesData[index].MinNum = _projectilesData[index - 1].MaxNum;
        }
        _projectilesData[index].MaxNum = _projectilesData[index].MinNum + percent;
    }
}

[System.Serializable]
public struct ProjectileData
{
    [SerializeField] private Projectile _projectile;
    [Space]
    [Range(0, 100)]
    [SerializeField] private int _spawnPercent;

    public Projectile Projectile => _projectile;
    public int SpawnPercent
    {
        get => _spawnPercent;
        set => _spawnPercent = value;
    }
    public int TempPercent { get; set; }
    public int MinNum { get; set; }
    public int MaxNum { get; set; }
}
