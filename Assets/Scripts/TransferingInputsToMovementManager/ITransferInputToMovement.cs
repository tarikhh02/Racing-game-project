using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TransferingInputsToMovementManager
{
    public interface ITransferInputToMovement
    {
        public void TransferInputsToMovementData(float direction, bool isRotationalMovement);
        public void TransferInputsToMovementData(Vector3 frontDirection, Vector3 sideDirection, Vector3 rotationDirection);
    }
}