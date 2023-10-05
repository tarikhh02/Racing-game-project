using Assets.Scripts;
using Racing_game_project.AIInputManager;
using Race_game_project.AICarMovement;
using UnityEngine;
using Race_game_project.AIPathFinderManager;

namespace Racing_game_project.AICollisionHandler
{
    public class AICollisionHandler : MonoBehaviour
    {
        AIInputManager.IAIInputManager _aiInputManagerComponent;
        IAICarMovement _aiManager;
        private void Awake()
        {
            _aiInputManagerComponent = this.gameObject.GetComponent<AIInputManager.AIInputManager>();
            _aiManager = this.GetComponent<AICarMovement>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "End")
            {
                _aiManager.SetIsSecondHalfOfGrid(false);
                _aiInputManagerComponent.SetArrived(true);
                _aiInputManagerComponent.SetDirection(new Vector3(1, 0, 0));
            }
            else if (other.gameObject.tag == "HalfTrack")
            {
                _aiManager.SetIsSecondHalfOfGrid(true);
                _aiInputManagerComponent.SetArrived(true);
                _aiInputManagerComponent.SetDirection(new Vector3(-1, 0, 0));
            }
            else if (other.gameObject.tag == "AlternativePathDecision")
            {
                if (Random.value < 0.5f)
                {
                    _aiInputManagerComponent.SetArrived(true);
                    _aiInputManagerComponent.SetDirection(new Vector3(0, 0, -1));
                }
            }
            else if(other.gameObject.tag == "SecondStart")
            {
                _aiInputManagerComponent.SetArrived(false);
                _aiManager.SetNewPath();
            }
            else if (other.gameObject.tag == "Start")
            {
                _aiInputManagerComponent.SetArrived(false);
                _aiManager.SetNewPath();
            }
            else if (other.gameObject.tag == "AlternativePath")
            {
                _aiInputManagerComponent.SetArrived(false);
                _aiManager.SetNewPath();
            }
        }
    }
}