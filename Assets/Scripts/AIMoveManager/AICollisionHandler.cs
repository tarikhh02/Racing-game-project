using Racing_game_project.AIInputManager;
using UnityEngine;

namespace Racing_game_project.AICollisionHandler
{
    public class AICollisionHandler : MonoBehaviour
    {
        AIInputManager.IAIInputManager _aiInputManagerComponent;
        private void Awake()
        {
            _aiInputManagerComponent = this.gameObject.GetComponent<AIInputManager.AIInputManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "End")
            {
                //_aiInputManagerComponent.SetArrived(true); -- When race is finished
                _aiInputManagerComponent.SetDirection(new Vector3(0, 0, 1));
                ResetAIPath();
            }
            else if (other.gameObject.tag == "HalfTrack")
            {
                _aiInputManagerComponent.SetDirection(new Vector3(0, 0, -1));
                ResetAIPath();            
            }
        }
        private void ResetAIPath()
        {
            //CalculatePath
        }
    }
}