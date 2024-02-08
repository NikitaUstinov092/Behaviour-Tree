using UnityEngine;

namespace Common
{
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
}
