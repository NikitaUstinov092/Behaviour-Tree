using Plugins.Blackboard;
using UnityEngine;

public class CanChopSensor : MonoBehaviour
{
    [SerializeField] 
    private Blackboard blackboard;
    
    private void Update()
    {
        CheckDistance();
    }
    
    private void CheckDistance()
    {
        if(!blackboard.TryGetVariable(BlackboardKeys.TREE, out Tree tree))
        {
            return;
        }
        if(!blackboard.TryGetVariable(BlackboardKeys.UNIT, out Character character))
        {
            return;
        }
        
        if (tree == null || character == null)
        {
            return;
        }

        if (Vector3.Distance(tree.transform.position, character.transform.position) < 1)
        {
            blackboard.SetVariable(BlackboardKeys.DISTANCE_ALLOWS_CHOP, true);
        }
        else
        {
            blackboard.SetVariable(BlackboardKeys.DISTANCE_ALLOWS_CHOP, false);
        }
    }
}
