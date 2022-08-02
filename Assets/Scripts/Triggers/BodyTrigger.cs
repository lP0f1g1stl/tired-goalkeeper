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
            }
        }
        if (collision.gameObject.TryGetComponent(out Bomb bomb)) 
        {
            if (!bomb.IsCollidedWithGoalkeeper)
            {
                bomb.IsCollidedWithGoalkeeper = true;
                OnBallCollision?.Invoke(bomb.Points);
                bomb.gameObject.SetActive(false);
            }
        }
    }
}
