using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateTrigger : MonoBehaviour
{

    public event Action<Projectile> OnGoal; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball Ball)) 
        {
            if (Ball.IsCollidedWithGoalkeeper)
            {
                OnGoal?.Invoke(Ball);
            }
            else 
            {
                OnGoal?.Invoke(Ball);
            }
        }
    }
}
