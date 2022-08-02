using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateTrigger : MonoBehaviour
{

    public event Action<int> OnGoal; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball)) 
        {
            if (ball.IsCollidedWithGoalkeeper)
            {
                OnGoal?.Invoke(-ball.Points *2);
            }
            else 
            {
                OnGoal?.Invoke(-ball.Points);
            }
        }
    }
}
