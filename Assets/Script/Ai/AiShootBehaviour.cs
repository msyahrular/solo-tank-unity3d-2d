using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootBehaviour : AIBehaviour
{
    public float filedOfVisionForShooting = 60;

    public override void PerformAction(TankController tank, AiDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HadleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }

        tank.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFOV(TankController tank, AiDetector detector)
    {
        var direction = detector.Target.position - tank.aimTurret.transform.position;
        if (Vector2.Angle(tank.aimTurret.transform.right, direction) < filedOfVisionForShooting / 2)
        {
            return true;
        }
        return false;
    }
}
