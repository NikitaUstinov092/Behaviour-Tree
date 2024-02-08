using Plugins.Blackboard;
using UnityEngine;

namespace Sensors
{
    public class BackPackFullSensor : MonoBehaviour
    {
        [SerializeField] 
        private Character character;
    
        [SerializeField] 
        private Blackboard blackboard;
   
        private void Awake()
        {
            character.OnResourceAmountChanged += CheckBackPackFull;
        }

        private void OnDisable()
        {
            character.OnResourceAmountChanged -= CheckBackPackFull;
        }
    
        private void CheckBackPackFull(bool isFull)
        {
            blackboard.SetVariable(BlackboardKeys.BACK_PACK_FULL, isFull);
        }
    }
}
