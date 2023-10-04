using UnityEngine;
using Assets.Scripts.MovementManager;
using Unity.VisualScripting;
using Racing_game_project.AIInputManager;
using System;

namespace Race_game_project.WheelAnimationManager
{
    public class ManageWheelRotation : MonoBehaviour
    {
        [SerializeField]
        GameObject[] _wheels;
        [SerializeField]
        GameObject[] _frontWheels;
        [SerializeField]
        bool _isPlayer = false;
        IObjectMover _objectMoveComponent;
        IAIInputManager _aiInputManager;
        private void Awake()
        {
            _objectMoveComponent = this.GetComponent<ObjectMover>();
            if(!_isPlayer)
                _aiInputManager = this.GetComponent<AIInputManager>();
        }
        private void Update()
        {
            RotateWheels();
        }
        private void RotateWheels()
        {
            float speed = _objectMoveComponent.GetSpeed();
            float steeringSpeed = _objectMoveComponent.GetSteeringAngle();
            if (_isPlayer)
                RotateFrontWheelsSideWaysForPlayer(steeringSpeed);
            else
                RotateFrontWheelsSideWaysForAI(steeringSpeed);
            RotateWheelsForwards(speed);
        }

        private void RotateFrontWheelsSideWaysForAI(float steeringSpeed)
        {
            float rotationDirection = _aiInputManager.GetSideDirection();
            RotateSideWays(steeringSpeed, rotationDirection);
        }

        private void RotateFrontWheelsSideWaysForPlayer(float steeringSpeed)
        {
            RotateSideWays(steeringSpeed, Input.GetAxis("Horizontal"));
        }

        private void RotateSideWays(float steeringSpeed, float direction)
        {
            foreach (var wheel in _frontWheels)
            {
                float currentAngle = wheel.transform.localEulerAngles.y;
                if (currentAngle != 0 && currentAngle != 360 && direction < 0)
                    currentAngle = 360 - currentAngle;
                if (currentAngle > 90)
                    steeringSpeed = 0;
                print(currentAngle);
                float rotationPos = this.transform.localEulerAngles.y + steeringSpeed / 2 * direction;
                wheel.transform.localRotation = Quaternion.Euler(new Vector3(0, steeringSpeed / 2 * direction, 0));
            }
        }

        private void RotateWheelsForwards(float speed)
        {
            foreach (var wheel in _wheels)
            {
                wheel.transform.Rotate(new Vector3(speed, 0, 0));
            }
        }
    }
}
