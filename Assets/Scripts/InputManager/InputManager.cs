using Assets.Scripts.MovementManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        IObjectMover _movePlayerComponent;
        private void Awake()
        {
            _movePlayerComponent = this.GetComponent<ObjectMover>();
        }
        private void Update()
        {

        }
        public void ManageInputs()
        {
            Vector3 forwardVector = this.transform.forward;
            Vector3 sideVector;
            Vector3 rotationVector;
            if (_movePlayerComponent.GetSpeed() != 0)
            {
                rotationVector = new Vector3(0, Input.GetAxis("Horizontal"), 0);
                sideVector =  this.transform.right * Input.GetAxis("Horizontal");
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