using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostNav : MonoBehaviour
{
    public static GhostNav instance;
    void Awake() {instance = this;}

    public static NavMeshHit navHit;

    public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) 
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
           
        randomDirection += origin;
              
        NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
           
        return navHit.position;
    }

    public void GoToPoint(NavMeshAgent agent)
    {
        StartCoroutine("GoTo", agent);
    }

    IEnumerator GoTo(NavMeshAgent agent)
    {
        if(!GetComponent<Ghost>().gFollow && GameManager.Instance.State == GameState.Day)
        {
            agent.SetDestination(RandomNavSphere(agent.transform.position, 3.5f, -1));
            agent.speed = agent.speed/2;
            yield return new WaitForSeconds(4);
            StartCoroutine("GoTo", agent);
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine("GoTo", agent);
        }
    }
}
