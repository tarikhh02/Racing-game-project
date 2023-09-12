using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.MovementManager
{
    public interface IObjectMover
    {
        public void Move(Vector3 frontMovement, Vector3 sideMovement, Vector3 rotationMovement);
        public float GetSpeed();
    }
}