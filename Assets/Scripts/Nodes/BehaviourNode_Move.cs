using System.Collections;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

namespace Nodes
{
    public class BehaviourNode_Move : BehaviourNode
    {
        [SerializeField] 
        protected Blackboard blackboard;
        
        [SerializeField] 
        protected float stoppingDistance ;
        
        protected Coroutine coroutine;

        protected override void Run()
        {

        }

        protected override void OnAbort()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

        }

        protected IEnumerator MoveToPosition(Character unit, Transform target)
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
                yield return period;
            }

            yield return period;

            Return(true);
        }
    }
}