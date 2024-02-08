using Lessons.AI.HierarchicalStateMachine;
using UnityEngine;


    [RequireComponent(typeof(Blackboard))]
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var blackboard = this.GetComponent<Blackboard>();
            // blackboard.SetVariable(BlackboardKeys.TREE, null);
            // blackboard.SetVariable(BlackboardKeys.BARN_FULL, false);
        }
    }

