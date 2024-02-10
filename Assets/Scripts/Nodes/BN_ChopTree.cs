using System.Collections;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BN_ChopTree : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;

    private Coroutine coroutine;
    
    protected override void Run()
    {
        if (!this.blackboard.TryGetVariable(BlackboardKeys.DISTANCE_ALLOWS_CHOP, out bool _) ||
            !this.blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character character) ||
            !this.blackboard.TryGetVariable(BlackboardKeys.TREE, out Tree tree))
        {
            this.Return(false);
            return;
        }
        this.coroutine = this.StartCoroutine(this.Chop(character, tree));
    }
    
    protected override void OnDispose()
    {
        if (this.coroutine != null)
        {
            this.StopCoroutine(this.coroutine);
        }
    }

    private IEnumerator Chop(Character character, Tree tree)
    {
        while (true)
        {
            if (!tree.HasResources())
            {
                Return(false);
                break;
            }
            character.Chop(tree);
            Debug.Log("ChopTree");
            yield return new WaitForSeconds(1);
        }
        this.Return(true);
    }
}
