using Assets.Scripts;
using Racing_game_project.AIInputManager;
using Race_game_project.AICarMovement;
using UnityEngine;
using Race_game_project.AIPathFinderManager;
using Assets.Scripts.MovementManager;

namespace Racing_game_project.AICollisionHandler
{
    public class AICollisionHandler : MonoBehaviour
    {
        AIInputManager.IAIInputManager _aiInputManagerComponent;
        IAICarMovement _aiManager;
        IObjectMover _objectMover;
        private void Awake()
        {
            _aiInputManagerComponent = this.gameObject.GetComponent<AIInputManager.AIInputManager>();
            _aiManager = this.GetComponent<AICarMovement>();
            _objectMover = this.GetComponent<ObjectMover>();
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
            else if (other.gameObject.tag == "BreakingDecision")
            {
                float x = Random.value;
                if (x < 0.7f && _objectMover.GetSpeed() >= _objectMover.GetMaxMovementSpeed() / 4 + 1)
                {
                    _objectMover.GetSpeed() -= _objectMover.GetMaxMovementSpeed() / 4 + 1;
                }
            }
            else if (other.gameObject.tag == "AlternativePathDecision")
            {
                if (_objectMover.GetSpeed() <= (_objectMover.GetMaxMovementSpeed() - _objectMover.GetMaxMovementSpeed() / 4))
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