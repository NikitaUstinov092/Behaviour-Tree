using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common
{
    public class TreesStorage: MonoBehaviour
    {
        public event Action<List<Tree>> OnTreesListChanged;
       
        [ShowInInspector, ReadOnly]
        private readonly List<Tree> trees = new();
        
        
        public void AddTree(Tree tree)
        {
            if (trees.Contains(tree))
                return;
            
            trees.Add(tree);
            OnTreesListChanged?.Invoke(trees);
        }
        
        public void RemoveTree(Tree tree)
        {
            if (!trees.Contains(tree)) 
                return;
            
            trees.Remove(tree);
            OnTreesListChanged?.Invoke(trees);
        }
    }
}