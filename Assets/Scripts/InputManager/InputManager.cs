using Assets.Scripts.MovementManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        IObjectMover _movePlayerComponent;
        float _sideSpeed = 0.25f;
        float _speed = 0.5f;
        float _steeringAngle = 10f;
        private void Awake()
        {
            _movePlayerComponent = this.GetComponent<ObjectMover>();
        }
        private void Update()
        {
            //Just started, working on build up speed and steering wheel sensitivity while car is getting faster it should be more sensitive
            //In theory steering wheel should be capped by the steering speed
            //Note: Input axis should be considered in speed properties, code might need refactoring, input logic might need to be changed
            //Mechanic doesn't work properly
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _steeringAngle += 5f;
            }
            else
            {
                _steeringAngle = 10f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _speed += 0.3f;
                _sideSpeed = _speed / 2;
            }
            else
            {
                _speed = 0.5f;
                _sideSpeed = _speed / 2;
            }
            print(_sideSpeed + " " +_speed + " " + _steeringAngle);
        }
        public void ManageInputs()
        {
            Vector3 forwardVector = this.transform.forward * Input.GetAxis("Vertical") * _speed * Time.deltaTime;
            Vector3 sideVector;
            Vector3 rotationVector;
            if (Input.GetAxis("Vertical") != 0)
            {
                rotationVector = new Vector3(0, Input.GetAxis("Horizontal") * _steeringAngle * Time.deltaTime, 0);
                sideVector =  this.transform.right * Input.GetAxis("Horizontal") * _sideSpeed * Time.deltaTime;
            }
            else
            {
                rotationVector = new Vector3(0, 0, 0);
                sideVector = new Vector3(0, 0, 0);
            }
            _movePlayerComponent.Move(forwardVector, sideVector, rotationVector);
        }
    }
}