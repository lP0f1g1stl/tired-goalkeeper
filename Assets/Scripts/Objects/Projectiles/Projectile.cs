using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private int _points;
    [SerializeField] private ProjectileType _projectileType;

    private Rigidbody _rb;

    public bool IsCollidedWithGoalkeeper { get; set; }
    public int Points => _points;
    public ProjectileType ProjectileType => _projectileType;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _rb.velocity = Vector3.zero;
        IsCollidedWithGoalkeeper = false;
        StartRemoveTimer();
    }
    public void SetSpeed(Vector3 force) 
    {
        _rb.AddRelativeForce(force, ForceMode.Impulse);
    }
    public void StartRemoveTimer() 
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}
