using System.Collections;
using UnityEditor.U2D;
using UnityEngine;

namespace Assets.Scripts.SpeedManager
{
    public class SpeedManager : MonoBehaviour, ISpeedManager
    {
        [SerializeField]
        float throtle = 0.005f;
        [SerializeField]
        float rotationSensitivity = 0.5f;
        [SerializeField]
        float drag = 0.004f;
        [SerializeField]
        float breakingForce = 0.007f;
        public void ManageForwardMovement(ref float speed, ref float steeringAngle, float minMovingForwardConstraint, float maxMovingForwardConstraint, float maxSteeringRotation, int forwardDirection)
        {
            if (speed >= minMovingForwardConstraint && speed <= maxMovingForwardConstraint)
            {
                MoveForward(ref speed, ref steeringAngle, maxSteeringRotation, forwardDirection);
            }
            else
            {
                Break(ref speed, ref steeringAngle, forwardDirection);
            }
        }

        public void MoveForward(ref float speed, ref float steeringAngle, float maxSteeringRotation, int forwardDirection)
        {
            speed += throtle * forwardDirection;
            if (steeringAngle < maxSteeringRotation)
                steeringAngle += rotationSensitivity;
        }

        public void Break(ref float speed, ref float steeringAngle, int forwardDirection)
        {
            speed += (breakingForce + drag) * forwardDirection;
            if (steeringAngle > 0)
                steeringAngle -= rotationSensitivity;
        }

        public void IncrementSteerinAngle(ref float steeringAngle, float maxSteeringRotation)
        {
            if (steeringAngle < maxSteeringRotation)
                steeringAngle += rotationSensitivity / 2;
        }
        public  void ApplyDrag(ref float speed, ref float steeringAngle)
        {
            if (steeringAngle > 0)
                steeringAngle -= rotationSensitivity / 2;
            else
                steeringAngle = 0;
            if (speed > 0)
                speed -= drag;
            else if (speed < -0.1f)
                speed += drag;
            else
                speed = 0;
        }
    }
}