using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using Assets.Scripts.TransferingInputsToMovementManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        IObjectMover _movePlayerComponent;
        ITransferInputToMovement _inputTransferComponent;
        private void Awake()
        {
            _movePlayerComponent = this.GetComponent<ObjectMover>();
            _inputTransferComponent = this.GetComponent<TransferInputToMovement>();
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
            _inputTransferComponent.TransferInputsToMovementData(forwardVector, sideVector, rotationVector);
        }
        public void GetKeys()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _inputTransferComponent.TransferInputsToMovementData(1, false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _inputTransferComponent.TransferInputsToMovementData(-1, false);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _inputTransferComponent.TransferInputsToMovementData(0, true);
            }
            else
            {
                _inputTransferComponent.TransferInputsToMovementData(0, false);
            }
        }
    }
}