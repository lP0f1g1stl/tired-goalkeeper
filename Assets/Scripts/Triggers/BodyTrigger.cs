using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyTrigger : MonoBehaviour
{
    public event Action<int> OnBallCollision;
    public event Action<int> OnCoinCollision;

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
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            if (!coin.IsCollidedWithGoalkeeper)
            {
                coin.IsCollidedWithGoalkeeper = true;
                OnCoinCollision?.Invoke(coin.Points);
                coin.gameObject.SetActive(false);
            }
        }
    }
}
