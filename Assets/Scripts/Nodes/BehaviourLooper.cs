using Plugins.BehaviourTree;
using UnityEngine;

namespace Nodes
{
    public sealed class BehaviourLooper : MonoBehaviour
    {
        [SerializeField]
        private BehaviourNode root;

        private void FixedUpdate()
        {
            if (!this.root.IsRunning)
            {
                this.root.Run(null);
            }
        }
    }
}