using Assets.Scripts.ClampManagerScripts;
using Assets.Scripts.SpeedManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MovementManager
{
    public class ObjectMover : MonoBehaviour, IObjectMover
    {
        IClampingDeterminationManager _clampManager;
        ISpeedManager _speedManager;
        float _sideSpeed = 0;
        float _speed = 0;
        float _steeringAngle = 0;
        private void Awake()
        {
            _clampManager = this.GetComponent<ClampingDeterminationManager>();
            _speedManager = this.GetComponent<SpeedManager.SpeedManager>();
        }
        private void Update()
        {
            _speedManager.ManageSpeed(ref _speed, ref _steeringAngle);
            _sideSpeed = _speed / 4;
        }
        public void Move(Vector3 frontMovement, Vector3 sideMovement, Vector3 rotationMovement)
        {
            frontMovement *= Time.deltaTime * _speed;
            sideMovement *=  Time.deltaTime * _sideSpeed;
            rotationMovement *= Time.deltaTime * _steeringAngle;
            if (!_clampManager.PlayerMovementNeedsToBeClamped())
            {
                this.transform.localPosition += frontMovement;
                this.transform.localPosition += sideMovement;
                this.transform.Rotate(rotationMovement);
            }
        }
        public float GetSpeed()
        {
            return _speed;
        }
    }
}