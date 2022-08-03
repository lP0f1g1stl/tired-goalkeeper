using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateTrigger : MonoBehaviour
{

    public event Action<int> OnGoal; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball projectile))
        {
            if (!projectile.IsCollidedWithGoalkeeper)
            {
                OnGoal?.Invoke(-projectile.Points);
            }
            else
            {
                OnGoal?.Invoke(-projectile.Points * 2);
            }
        }
    }
}
