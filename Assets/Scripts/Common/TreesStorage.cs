using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sample.Common
{
    public class TreesStorage: MonoBehaviour
    {
        public event Action<List<Transform>> OnTreesListChanged;
       
        [ShowInInspector, ReadOnly]
        private readonly List<Transform> trees = new();

        public void SetUp(params Transform[] massTrees)
        {
            foreach (var tree in massTrees)
            {
                trees.Add(tree);
            }
            OnTreesListChanged?.Invoke(trees);
        }
        
        public void AddTree(Transform tree)
        {
            if (!trees.Contains(tree))
                return;
            
            trees.Add(tree);
            OnTreesListChanged?.Invoke(trees);
        }
        
        public void RemoveTree(Transform tree)
        {
            if (!trees.Contains(tree)) 
                return;
            
            trees.Remove(tree);
            OnTreesListChanged?.Invoke(trees);
        }
    }
}