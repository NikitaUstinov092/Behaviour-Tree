using System.Collections;
using System.Collections.Generic;
using Sample.Common;
using UnityEngine;

[RequireComponent(typeof(TreesStorage))]
public class TreeStorageInstaller : MonoBehaviour
{
    [SerializeField] 
    private Transform[] trees;
    private void Start()
    {
        GetComponent<TreesStorage>().SetUp(trees);
    }
}
