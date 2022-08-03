using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateTrigger : MonoBehaviour
{

    public event Action<Projectile> OnGoal; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Projectile projectile)) 
        {
            if (projectile.IsCollidedWithGoalkeeper)
            {
                OnGoal?.Invoke(projectile);
            }
            else 
            {
                OnGoal?.Invoke(projectile);
            }
        }
    }
}
