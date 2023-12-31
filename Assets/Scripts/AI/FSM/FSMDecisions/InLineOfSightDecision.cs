using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/FSM/Decisions/InLineOfSightDecision")]
public class InLineOfSightDecision : Decision
{
    public LayerMask layerMask;
    public float distThreshold = 3f; // distance to check against
    Vector3 prevPos = Vector3.zero;
    Vector3 prevDir = Vector3.zero;

    public override bool Decide(BaseStateMachine stateMachine)
    {
        /*
         * 
        Vector3 dir = (stateMachine.transform.position - prevDir).normalized;
        dir = (dir.Equals(Vector3.zero)) ? prevDir : dir;
        RaycastHit2D hit = Physics2D.Raycast(stateMachine.transform.position, dir, distThreshold, layerMask);
        prevPos = stateMachine.transform.position;
        prevDir = dir;
        Debug.Log((hit.collider != null) + "in line of sight");
        return (hit.collider != null) ? true : false;
         */
        GameObject target = GameObject.FindWithTag("Player");
        Vector3 direction = (target.transform.position - stateMachine.transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(stateMachine.gameObject.transform.position, direction,distThreshold,layerMask);
        if (hit.collider != null)
        {
	        if (hit.collider.gameObject != target) return false;
	        Debug.Log("HIT");
	        return true;
        }
        Debug.Log("NO HIT");
        return false;
    }
}
