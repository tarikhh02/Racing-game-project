using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.MovementManager
{
    public interface IObjectMover
    {
        public void Move(Vector3 frontMovement, Vector3 sideMovement, Vector3 rotationMovement);
        public ref float GetSpeed();
        public ref float GetSideSpeed();
        public ref float GetSteeringAngle();
        public ref float GetMaxMovementSpeed();
        public ref float GetMaxSteeringAngle();
    }
}