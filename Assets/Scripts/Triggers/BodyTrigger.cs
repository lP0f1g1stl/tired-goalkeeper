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
                OnCollision?.Invoke(projectile);
            }
        }
    }
}
