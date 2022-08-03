using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyTrigger : MonoBehaviour
{
    public event Action<Projectile> OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Projectile projectile))
        {
            if (!projectile.IsCollidedWithGoalkeeper)
            {
                projectile.IsCollidedWithGoalkeeper = true;
                switch (projectile.ProjectileType)
                {
                    case ProjectileType.Ball:
                        break;
                    case ProjectileType.Bomb:
                        projectile.gameObject.SetActive(false);
                        break;
                    case ProjectileType.Coin:
                        projectile.gameObject.SetActive(false);
                        break;
                }
                OnCollision?.Invoke(projectile);
            }
        }
    }
}
