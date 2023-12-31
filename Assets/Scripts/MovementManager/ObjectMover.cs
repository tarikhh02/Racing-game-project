﻿using Assets.Scripts.ClampManagerScripts;
using Assets.Scripts.SpeedManager;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.MovementManager
{
    public class ObjectMover : MonoBehaviour, IObjectMover
    {
        [SerializeField]
        float maxMovementSpeed = 4f;
        [SerializeField]
        float maxSteeringRotation = 80f;
        float _sideSpeed = 0;
        float _speed = 0;
        float _steeringAngle = 0;
        public void Move(Vector3 frontMovement, Vector3 sideMovement, Vector3 rotationMovement)
        {
            frontMovement *= Time.deltaTime * _speed;
            sideMovement *=  Time.deltaTime * _sideSpeed;
            rotationMovement *= Time.deltaTime * _steeringAngle;
            this.transform.localPosition += frontMovement;
            this.transform.localPosition += sideMovement;
            this.transform.Rotate(rotationMovement);
        }
        public ref float GetSpeed()
        {
            return ref _speed;
        }
        public ref float GetSideSpeed()
        {
            return ref _sideSpeed;
        }
        public ref float GetSteeringAngle()
        {
            return ref _steeringAngle;
        }
        public ref float GetMaxMovementSpeed()
        {
            return ref maxMovementSpeed;
        }
        public ref float GetMaxSteeringAngle()
        {
            return ref maxSteeringRotation;
        }
    }
}