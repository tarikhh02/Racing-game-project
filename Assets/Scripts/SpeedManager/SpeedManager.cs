using Assets.Scripts.MovementManager;
using System.Collections;
using UnityEditor.Experimental.GraphView;
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
        IObjectMover _moveObjectComponent;
        private void Awake()
        {
            _moveObjectComponent = GetComponent<ObjectMover>();
        }
        public void ManageForwardMovement(float forwardDirection)
        {
            ref float speed = ref _moveObjectComponent.GetSpeed();
            ref float steeringAngle = ref _moveObjectComponent.GetSteeringAngle();
            float maxSteeringRotation = _moveObjectComponent.GetMaxSteeringAngle();
            float movingForwardConstraint1 = 0f;
            float movingForwardConstraint2 = _moveObjectComponent.GetMaxMovementSpeed();
            if(forwardDirection == -1)
            {
                movingForwardConstraint1 = -_moveObjectComponent.GetMaxMovementSpeed();
                movingForwardConstraint2 = 0f;
            }
            if (speed >= movingForwardConstraint1 && speed <= movingForwardConstraint2)
            {
                MoveForward(ref speed, ref steeringAngle, maxSteeringRotation, forwardDirection);
            }
            else if(forwardDirection * speed < 0)
            {
                Break(ref speed, ref steeringAngle, forwardDirection);
            }
        }
        public void MoveForward(ref float speed, ref float steeringAngle, float maxSteeringRotation, float forwardDirection)
        {
            speed += throtle * forwardDirection;
            if (steeringAngle < maxSteeringRotation)
                steeringAngle += rotationSensitivity;
        }
        public void Break(ref float speed, ref float steeringAngle, float forwardDirection)
        {
            speed += (breakingForce + drag) * forwardDirection;
            if (steeringAngle > 0)
                steeringAngle -= rotationSensitivity;
        }
        public void IncrementSteerinAngle()
        {
            ref float steeringAngle = ref _moveObjectComponent.GetSteeringAngle();
            float maxSteeringRotation = _moveObjectComponent.GetMaxSteeringAngle();
            if (steeringAngle < maxSteeringRotation)
                steeringAngle += rotationSensitivity / 2;
        }
        public  void ApplyDrag()
        {
            ref float speed = ref _moveObjectComponent.GetSpeed();
            ref float steeringAngle = ref _moveObjectComponent.GetSteeringAngle();
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