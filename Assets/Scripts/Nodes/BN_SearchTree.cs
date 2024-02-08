using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

namespace Nodes
{
    public class BN_SearchTree : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;
    
        protected override void Run()
        {
            var hasTree = blackboard.HasVariable(BlackboardKeys.TREE);
            Return(hasTree);
        }
    }
}
