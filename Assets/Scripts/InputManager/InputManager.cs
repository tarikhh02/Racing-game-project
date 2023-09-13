using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        IObjectMover _movePlayerComponent;
        ISpeedManager _speedManager;
        private void Awake()
        {
            _movePlayerComponent = this.GetComponent<ObjectMover>();
            _speedManager = this.GetComponent<SpeedManager.SpeedManager>();
        }
        public void ManageInputs()
        {
            GetKeys();
            SetDirection();
        }

        private void SetDirection()
        {
            Vector3 forwardVector = this.transform.forward;
            Vector3 sideVector;
            Vector3 rotationVector;
            if (_movePlayerComponent.GetSpeed() != 0)
            {
                rotationVector = new Vector3(0, Input.GetAxis("Horizontal"), 0);
                sideVector = this.transform.right * Input.GetAxis("Horizontal");
            }
            else
            {
                rotationVector = new Vector3(0, 0, 0);
                sideVector = new Vector3(0, 0, 0);
            }
            _movePlayerComponent.Move(forwardVector, sideVector, rotationVector);
        }

        public void GetKeys()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _speedManager.ManageForwardMovement(ref _movePlayerComponent.GetSpeed(), ref _movePlayerComponent.GetSteeringAngle(), 0, _movePlayerComponent.GetMaxMovementSpeed(), _movePlayerComponent.GetMaxSteeringAngle(), 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _speedManager.ManageForwardMovement(ref _movePlayerComponent.GetSpeed(), ref _movePlayerComponent.GetSteeringAngle(),- _movePlayerComponent.GetMaxMovementSpeed(), 0, _movePlayerComponent.GetMaxSteeringAngle(), -1);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _speedManager.IncrementSteerinAngle(ref _movePlayerComponent.GetSteeringAngle(), _movePlayerComponent.GetMaxSteeringAngle());
            }
            else
            {
                _speedManager.ApplyDrag(ref _movePlayerComponent.GetSpeed(), ref _movePlayerComponent.GetSteeringAngle());
            }
        }
    }
}