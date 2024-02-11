using Common;
using UnityEngine;
using UnityEngine.Serialization;


public class TreeInitializer: MonoBehaviour
    {
        [SerializeField]
        private TreesStorage storage;
        
        [SerializeField]
        private Tree tree;

        [SerializeField] 
        private int resourceCount;
        
        private void OnEnable()
        {
            storage.AddTree(tree);
            if (!tree.HasResources())
            {
                tree.AddResource(resourceCount);
            }
        }
        
        private void OnDisable()
        {
            storage.RemoveTree(tree);
        }
    }
