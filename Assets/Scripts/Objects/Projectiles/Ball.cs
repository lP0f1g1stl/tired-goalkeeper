using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Projectile
{
    public bool IsCollidedWithGoalkeeper { get; set; }

    private void OnEnable()
    {
        IsCollidedWithGoalkeeper = false;
    }
}
