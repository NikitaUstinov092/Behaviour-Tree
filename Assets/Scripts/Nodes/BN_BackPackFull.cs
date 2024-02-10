using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

namespace Nodes
{
    public sealed class BN_BackPackFull : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField] 
        private bool requiredValue;
        protected override void Run()
        {
            var backPackFull = blackboard.HasVariable(BlackboardKeys.BACK_PACK_FULL);
            var checkedValue = backPackFull == requiredValue;
            Debug.Log("BackPackFull" + checkedValue);
            Return(checkedValue);
        }
    }
}