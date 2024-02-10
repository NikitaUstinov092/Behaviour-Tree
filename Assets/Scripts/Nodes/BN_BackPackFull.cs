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
            blackboard.TryGetVariable(BlackboardKeys.BACK_PACK_FULL, out bool iSFull);
            var checkedValue = iSFull == requiredValue;
            Debug.Log($"BackPackFull {checkedValue}, {gameObject.name}");
            Return(checkedValue);
        }
    }
}