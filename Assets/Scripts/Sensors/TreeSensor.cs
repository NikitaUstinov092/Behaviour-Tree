using System;
using System.Collections.Generic;
using Lessons.AI.HierarchicalStateMachine;
using Sample.Common;
using UnityEngine;

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
      _treesStorage.OnTreesListChanged += FindClosestTree;
   }
   private void OnDisable()
   {
      _treesStorage.OnTreesListChanged -= FindClosestTree;
   }
   private void FindClosestTree(List<Transform> trees)
   {
      if (character == null || trees == null || trees.Count == 0)
      {
         return;
      }

      Transform closestTree = null;
      var closestDistance = Mathf.Infinity;

      foreach (var tree in trees)
      {
         var distanceToTree = Vector3.Distance(character.position, tree.position);
         if (!(distanceToTree < closestDistance))
            continue;
        
         closestDistance = distanceToTree;
         closestTree = tree;
      }

      if (closestTree != null)
      {
         blackboard.SetVariable(BlackboardKeys.TREE, closestTree);
      }
   }
}
