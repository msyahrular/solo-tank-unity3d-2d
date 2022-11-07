using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrolPathBehaviour : AIBehaviour
{
   public PatrolPath patrolPath;
   [Range(0.1f, 1)]
   public float arriveDistance = 1;
   public float waitTime = 0.5f;
   [SerializeField]
   private bool isWaiting = false;
   [SerializeField]
   Vector2 currentPatrolTarget = Vector2.zero;
   bool isInitialized = false;

   private int currentIndex = -1;

   private void Awake()
   {
    if(patrolPath == null)
    patrolPath = GetComponentInChildren<PatrolPath>();
   }

    public override void PerformAction(TankController tank, AiDetector detector)
    {
        if (!isWaiting)
        {
            if (patrolPath.Length < 2)
                return;
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(tank.transform.position);
                this.currentIndex = currentPathPoint.Index;
                this.currentPatrolTarget = currentPathPoint.Position;
                isInitialized = true;
            }
            if (Vector2.Distance(tank.transform.position, currentPatrolTarget) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(waitCoroutine());
                return;
            }
        }
        Vector2 directionToGo = currentPatrolTarget - (Vector2)tank.tankMover.transform.position;
        var dotProduct = Vector2.Dot(tank.tankMover.transform.up, directionToGo.normalized);

        if (dotProduct< 0.98f)
        {
            var crossProduct = Vector3.Cross(tank.tankMover.transform.up, directionToGo.normalized);
            int rotationresult = crossProduct.z >= 0 ? -1 : 1;
            tank.HadleMoveBody(new Vector2(rotationresult, 1));
        }
        else
        {
            tank.HadleMoveBody(Vector2.up);
        }
    }

    IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
        currentPatrolTarget = nextPathPoint.Position;
        currentIndex = nextPathPoint.Index;
        isWaiting = false;
    }
}
