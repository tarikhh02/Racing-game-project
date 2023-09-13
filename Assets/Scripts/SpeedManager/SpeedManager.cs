using System.Collections;
using UnityEditor.U2D;
using UnityEngine;

namespace Assets.Scripts.SpeedManager
{
    public class SpeedManager : MonoBehaviour, ISpeedManager
    {
        [SerializeField]
        float maxMovementSpeed = 4f;
        [SerializeField]
        float maxSteeringRotation = 80f;
        [SerializeField]
        float throtle = 0.005f;
        [SerializeField]
        float rotationSensitivity = 0.5f;
        [SerializeField]
        float drag = 0.004f;
        [SerializeField]
        float breakingForce = 0.007f;
        public void ManageSpeed(ref float speed, ref float steeringAngle)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (speed >= 0 && speed < maxMovementSpeed)
                {
                    speed += throtle;
                    if (steeringAngle < maxSteeringRotation)
                        steeringAngle += rotationSensitivity;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (speed <= 0 && speed > -maxMovementSpeed)
                {
                    speed -= throtle;
                    if (steeringAngle < maxSteeringRotation)
                        steeringAngle += rotationSensitivity;
                } 
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (steeringAngle < maxSteeringRotation)
                    steeringAngle += rotationSensitivity / 2;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (steeringAngle < maxSteeringRotation)
                    steeringAngle += rotationSensitivity / 2;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                if (speed > 0)
                    speed -= breakingForce + drag;
                else
                    speed += breakingForce + drag;
                if (steeringAngle > 0)
                    steeringAngle -= rotationSensitivity;
            }
            else
            {
                if (steeringAngle > 0)
                    steeringAngle -= rotationSensitivity;
                else
                    steeringAngle = 0;
                if (speed > 0)
                    speed -= drag;
                else if (speed < -0.5f)
                    speed += drag;
                else
                    speed = 0;
            }
        } 
    }
}