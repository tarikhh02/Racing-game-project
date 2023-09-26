using Assets.Scripts;
using Racing_game_project.AIInputManager;
using UnityEngine;

namespace Racing_game_project.AICollisionHandler
{
    public class AICollisionHandler : MonoBehaviour
    {
        AIInputManager.IAIInputManager _aiInputManagerComponent;
        AICarMovement _aiManager;
        private void Awake()
        {
            _aiInputManagerComponent = this.gameObject.GetComponent<AIInputManager.AIInputManager>();
            _aiManager = this.GetComponent<AICarMovement>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "End")
            {
                _aiInputManagerComponent.SetDirection(new Vector3(1, 0, 0));
            }
            else if (other.gameObject.tag == "HalfTrack")
            {
                _aiInputManagerComponent.SetDirection(new Vector3(-1, 0, 0));
            }
            else if(other.gameObject.tag == "SecondStart")
            {
                _aiManager.SetPathFromHalf();
            }
            else if (other.gameObject.tag == "Start")
            {

            }
        }
    }
}