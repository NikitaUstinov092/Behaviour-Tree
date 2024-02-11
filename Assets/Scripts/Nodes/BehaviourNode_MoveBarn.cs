using Nodes;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviourNode_MoveBarn : BehaviourNode_Move
{
    
    [SerializeField] 
    private Transform target;
    
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
}

