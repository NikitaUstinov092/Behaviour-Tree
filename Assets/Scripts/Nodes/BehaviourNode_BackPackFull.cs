using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

namespace Nodes
{
    public sealed class BehaviourNode_BackPackFull : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField] 
        private bool requiredValue;
        protected override void Run()
        {
            blackboard.TryGetVariable(BlackboardKeys.BACK_PACK_FULL, out bool iSFull);
            Return(iSFull == requiredValue);
        }
    }
}