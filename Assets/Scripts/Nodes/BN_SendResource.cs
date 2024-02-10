using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BN_SendResource : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;

    [SerializeField] 
    private Barn barn;
    
    private Coroutine coroutine;
    
    protected override void Run()
    {
        if (!blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character character) || barn.IsFull())
        {
            Return(false);
        }
        else
        {
            barn.AddResources(character.UnloadResources());
            Return(true);
        }
    }
}
