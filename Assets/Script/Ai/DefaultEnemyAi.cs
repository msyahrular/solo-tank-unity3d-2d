using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAi : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehavior, patrolBehavior;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    private AiDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AiDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if(detector.TargetVisible)
        {
            shootBehavior.PerformAction(tank, detector);
        }
        else
        {
            patrolBehavior.PerformAction(tank, detector);
        }
    }
}
