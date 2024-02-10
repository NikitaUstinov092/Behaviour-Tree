using System.Collections;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

namespace Nodes
{
    public class BN_MoveToTree : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;
        private Coroutine coroutine;
    
        private const float StoppingDistance = 1f;
    
        protected override void Run()
        {
            if (!blackboard.TryGetVariable(BlackboardKeys.TREE, out Tree target) 
                ||!blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character unit)
                || target == null)
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

                if (distanceVector.magnitude <= StoppingDistance)
                {
                    break;
                }

                Vector3 direction = distanceVector.normalized;
                unit.Move(direction);
                Debug.Log("MoveToTree");
                yield return period;
            }
            
            yield return period;

            Return(true);
        }
    }
}
