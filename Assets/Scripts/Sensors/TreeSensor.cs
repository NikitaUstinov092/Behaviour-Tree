using System.Collections.Generic;
using Common;
using Plugins.Blackboard;
using UnityEngine;

namespace Sensors
{
   public class TreeSensor : MonoBehaviour
   {
      [SerializeField] 
      private Transform character;
   
      [SerializeField] 
      private Blackboard blackboard;

      [SerializeField] 
      private TreesStorage _treesStorage;
      private void Awake()
      {
         Debug.Log("Awake");
         _treesStorage.OnTreesListChanged += FindClosestTree;
      }
      private void OnDisable()
      {
         _treesStorage.OnTreesListChanged -= FindClosestTree;
      }
      private void FindClosestTree(List<Tree> trees)
      {
         if (character == null || trees == null || trees.Count == 0)
         {
            return;
         }

         Tree closestTree = null;
         var closestDistance = Mathf.Infinity;

         foreach (var tree in trees)
         {
            var distanceToTree = Vector3.Distance(character.position, tree.transform.position);
            if (!(distanceToTree < closestDistance))
               continue;
        
            closestDistance = distanceToTree;
            closestTree = tree;
         }

         if (closestTree != null && closestTree.gameObject.activeInHierarchy)
         {
            blackboard.SetVariable(BlackboardKeys.TREE, closestTree);
         }
      }
   }
}
