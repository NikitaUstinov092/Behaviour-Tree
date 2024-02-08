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
    
        private const float StoppingDistance = 3f;
    
        protected override void Run()
        {
            if (!blackboard.TryGetVariable(BlackboardKeys.TREE, out Transform target) 
                ||!blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character unit)
                || target == null)
            {
                Return(false);
                return;
            }

            coroutine = StartCoroutine(MoveToPosition(unit, target));
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
            var unitPosition = unit.transform.position;
            var targetPosition = target.position;
        
            var period = new WaitForFixedUpdate();

            while (true)
            {
                if (target == null)
                {
                    Return(false);
                    yield break; 
                }
            
                Vector3 distanceVector = targetPosition - unitPosition;

                if (distanceVector.magnitude <= StoppingDistance)
                {
                    Return(true); // добавил может убрать потом
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
