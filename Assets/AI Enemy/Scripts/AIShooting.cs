using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : AIBehaviour
{
    public float feildOfVisionForShooting = 60;
    public override void PerformAction(EnemyController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }
            
        tank.HandleTurretMovement(detector.Target.position);
    }

    public bool TargetInFOV(EnemyController tank, AIDetector detector)
    {
        var direction = detector.Target.position - tank.aimTurret.transform.position;
        if (Vector2.Angle(tank.aimTurret.transform.right, direction) < feildOfVisionForShooting /2)
        {
            return true;
        }
        return false;
    }
}
