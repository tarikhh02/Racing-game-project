using UnityEngine;
using Assets.Scripts.MovementManager;

namespace Race_game_project.WheelAnimationManager
{
    public class ManageWheelRotation : MonoBehaviour
    {
        [SerializeField]
        GameObject[] wheels;
        GameObject[] frontWheels;
        IObjectMover _objectMoveComponent;
        private void Awake()
        {
            frontWheels = new GameObject[] { wheels[0], wheels[1]};
            _objectMoveComponent = this.GetComponent<ObjectMover>();
        }
        private void Update()
        {
            RotateWheels();
        }
        private void RotateWheels()
        {
            float speed = _objectMoveComponent.GetSpeed();
            float steeringSpeed = _objectMoveComponent.GetSteeringAngle();
            foreach (var wheel in wheels)
            {
                wheel.transform.Rotate(new Vector3(speed, 0, 0));
            }
            //foreach (var wheel in frontWheels)
            //{
            //    if (wheel.transform.rotation.eulerAngles.y < 70)
            //        speed = 0;
            //    wheel.transform.RotateAroundLocal(Vector3.up, steeringSpeed / 2 * Input.GetAxis("Horizontal") * Time.deltaTime);
            //}
        }
    }
}
