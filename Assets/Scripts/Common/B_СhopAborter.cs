using System;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class B_СhopAborter : MonoBehaviour
{
    [SerializeField]
    private Blackboard blackboard;

    [SerializeField]
    private BehaviourNode rootNode;
    
    private void OnEnable()
    {
        this.blackboard.OnVariableChanged += this.OnVariableChanged;
        this.blackboard.OnVariableRemoved += this.OnVariableChanged;
    }
        
    private void OnDisable()
    {
        this.blackboard.OnVariableChanged -= this.OnVariableChanged;
        this.blackboard.OnVariableRemoved -= this.OnVariableChanged;
    }

    private void OnVariableChanged(string name, object value)
    {
        if (name != BlackboardKeys.BACK_PACK_FULL) 
            return;
        
        if (value is true)
        {
            this.rootNode.Abort();
        }
    }
}
