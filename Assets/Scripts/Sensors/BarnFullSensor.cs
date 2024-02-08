using Plugins.Blackboard;
using UnityEngine;

namespace Sensors
{
   public class BarnFullSensor : MonoBehaviour
   {
      [SerializeField] 
      private Barn barn;
   
      [SerializeField] 
      private Blackboard blackboard;

      private void Awake()
      {
         barn.OnResourceAmountChanged += CheckBarnFull;
      }

      private void OnDisable()
      {
         barn.OnResourceAmountChanged -= CheckBarnFull;
      }

      private void CheckBarnFull(bool isFull)
      {
         blackboard.SetVariable(BlackboardKeys.BARN_FULL, isFull);
      }
   }
}
