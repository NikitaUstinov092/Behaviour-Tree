using System;
using System.Collections.Generic;
using Plugins.BehaviourTree;
using UnityEngine;

namespace Common
{
    public class TreeListChangedAborter: MonoBehaviour
    {
        [SerializeField] 
        private TreesStorage treesStorage;
        
        [SerializeField]
        private BehaviourNode rootNode;
        private void Start()
        {
            treesStorage.OnTreesListChanged += Abort;
        }

        private void OnDisable()
        {
            treesStorage.OnTreesListChanged -= Abort;
        }
        
        private void Abort(List<Tree> obj)
        {
            rootNode.Abort();
        }
        
    }
}