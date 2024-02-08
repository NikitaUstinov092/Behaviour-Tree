using Plugins.Blackboard;
using UnityEngine;

[RequireComponent(typeof(Blackboard))]
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField] 
        private Character unit;
        private void Awake()
        {
            var blackboard = this.GetComponent<Blackboard>();
            blackboard.SetVariable(BlackboardKeys.UNIT, unit);
        }
    }


