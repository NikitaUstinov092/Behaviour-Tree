using Plugins.Blackboard;


namespace Nodes
{
    public class BehaviourNode_MoveToTree : BehaviourNode_Move
    {
        
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
    }
}
