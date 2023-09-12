using Assets.Scripts.ClampManagerScripts;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MovementManager
{
    public class ObjectMover : MonoBehaviour, IObjectMover
    {
        [SerializeField]
        public float maxMovementSpeed = 4f;
        [SerializeField]
        public float maxSteeringRotation= 80f;
        IClampingDeterminationManager _clampManager;
        private void Awake()
        {
            _clampManager = this.GetComponent<ClampingDeterminationManager>();
        }
        public void Move(Vector3 frontMovement, Vector3 sideMovement, Vector3 rotationMovement)
        {
            frontMovement *= Time.deltaTime;
            sideMovement *=  Time.deltaTime;
            rotationMovement *= Time.deltaTime;
            if (!_clampManager.PlayerMovementNeedsToBeClamped())
            {
                this.transform.localPosition += frontMovement;
                this.transform.localPosition += sideMovement;
                this.transform.Rotate(rotationMovement);
            }
        }
    }
}