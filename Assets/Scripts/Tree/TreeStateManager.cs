using Common;
using UnityEngine;


    public class TreeStateManager: MonoBehaviour
    {
        [SerializeField]
        private TreesStorage storage;
        
        [SerializeField]
        private Tree tree;
        
        private void OnEnable()
        {
            storage.AddTree(tree);
        }
        
        private void OnDisable()
        {
            storage.RemoveTree(tree);
        }
    }
