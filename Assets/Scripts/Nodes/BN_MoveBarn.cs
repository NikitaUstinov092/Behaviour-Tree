using System.Collections;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BN_MoveBarn : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;

    [SerializeField] 
    private Transform target;
    
    [SerializeField] 
    private float stoppingDistance = 2f;
    
    private Coroutine coroutine;
    
    protected override void Run()
    {
        if (!blackboard.HasVariable(BlackboardKeys.BACK_PACK_FULL)
            ||!blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character unit))
        {
            Return(false);
            return;
        }
        coroutine = StartCoroutine(MoveToPosition(unit, target.transform));
    }
      
    protected override void OnAbort()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
               
    }
       
    private IEnumerator MoveToPosition(Character unit, Transform target)
    {
        var period = new WaitForFixedUpdate();
   
        while (true)
        {
            var unitPosition = unit.transform.position;
            var targetPosition = target.position;
                   
            if (target == null)
            {
                Return(false);
                yield break; 
            }
               
            Vector3 distanceVector = targetPosition - unitPosition;
   
            if (distanceVector.magnitude <= stoppingDistance)
            {
                break;
            }
   
            Vector3 direction = distanceVector.normalized;
            unit.Move(direction);
            Debug.Log("MoveToBarn");
            yield return period;
        }
               
        yield return period;
   
        Return(true);
    }
}

