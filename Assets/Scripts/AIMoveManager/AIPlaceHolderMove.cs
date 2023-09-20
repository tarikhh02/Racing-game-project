using Assets.Scripts.GridCellManager;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GridBrushBase;

namespace Assets.Scripts.AIMoveManager
{
    public class AIPlaceHolderMove : MonoBehaviour
    {
        public Vector3 direction;
        bool arrived = false;
        float _rotationSpeed = 20f;
        float _speed = 1f;
        float _rotationAngle;
        RaycastHit hit;
        private void Update()
        {
            ImplementMovement();
        }

        private void ImplementMovement()
        {
            if (!arrived && Physics.Raycast(this.transform.position, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.gameObject.tag == "GridCell")
                {
                    direction = hit.collider.gameObject.GetComponent<GridCell>().GetDirection();
                }
            }
            CalculateAngle();
            if((int)_rotationAngle != 0)
                Rotate();
            this.transform.position += this.transform.forward * Time.deltaTime * _speed;
        }

        private void CalculateAngle()
        {
            _rotationAngle = Vector3.SignedAngle(this.transform.forward, direction, new Vector3(0,1,0));
        }

        private void Rotate()
        {
            float currentYAngle = this.transform.rotation.eulerAngles.y;
            if (currentYAngle < _rotationAngle + this.transform.eulerAngles.y)
            {
                this.transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
            }
            else
            {
                this.transform.Rotate(new Vector3(0, -_rotationSpeed * Time.deltaTime, 0));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "End")
            {
                arrived = true;
                direction = new Vector3(0, 0, 1);
                Invoke(nameof(ResetArrived), 2f);
            }
            else if(other.gameObject.tag == "HalfTrack")
            {
                arrived = true;
                direction = new Vector3(0, 0, -1);
                Invoke(nameof(ResetArrived), 2f);
            }
        }
        private void ResetArrived()
        {
            arrived = false;
        }
    }
}