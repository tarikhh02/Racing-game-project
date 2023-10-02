using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TransferingInputsToMovementManager
{
    public class TransferInputToMovement : MonoBehaviour, ITransferInputToMovement
    {
        ISpeedManager _speedManager;
        IObjectMover _objectMover;
        private void Awake()
        {
            _speedManager = GetComponent<SpeedManager.SpeedManager>();
            _objectMover = GetComponent<ObjectMover>();
        }
        public void TransferInputsToMovementData(float direction, bool isRotationalMovement)
        {
            if (isRotationalMovement)
            {
                _speedManager.IncrementSteerinAngle();
            }
            else if (direction == 0)
            {
                _speedManager.ApplyDrag();
            }
            else if (direction == 1)
            {
                _speedManager.ManageForwardMovement(direction);
            }
            else if (direction == -1)
            {
                _speedManager.ManageForwardMovement(direction);
            }
        }
        public void TransferInputsToMovementData(Vector3 frontDirection, Vector3 sideDirection, Vector3 rotationDirection)
        {
            _objectMover.Move(frontDirection, sideDirection, rotationDirection);
        }
    }
}