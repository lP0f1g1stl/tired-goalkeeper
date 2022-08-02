using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyTrigger : MonoBehaviour
{
    public event Action<int> OnBallCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (!ball.IsCollidedWithGoalkeeper)
            {
                ball.IsCollidedWithGoalkeeper = true;
                OnBallCollision?.Invoke(ball.Points);
                Debug.Log(ball.Points);
            }
        }
        if (collision.gameObject.TryGetComponent(out Bomb bomb)) 
        {
            OnBallCollision?.Invoke(bomb.Points);
            Debug.Log(bomb.Points);
            //bomb.StopTimer();
            bomb.gameObject.SetActive(false);
        }
    }
}
