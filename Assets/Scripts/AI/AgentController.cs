using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public NavMeshAgent Agent { get; private set; }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Move to the target position
    /// </summary>
    public void GoToDestination(Vector3 targetPosition)
    {
        Agent.SetDestination(targetPosition);
    }

    /// <summary>
    /// Set agent stopping distance locally
    /// </summary>
    public void SetStopDistance(float stoppingDistance)
    {
        Agent.stoppingDistance = stoppingDistance;
    }

    /// <summary>
    /// Check if the agent has reached his destination
    /// </summary>
    /// <returns></returns>
    public bool DestinationReached()
    {
        if (Agent.remainingDistance <= Agent.stoppingDistance)
        {
            if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }

        return false;
    }
}
