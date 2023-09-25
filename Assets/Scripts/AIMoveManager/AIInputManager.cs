using Assets.Scripts.GridCellManager;
using Assets.Scripts.MovementManager;
using Assets.Scripts.TransferingInputsToMovementManager;
using Racing_game_project.AIDirectionSetter;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GridBrushBase;


namespace Racing_game_project.AIInputManager
{
    public class AIInputManager : MonoBehaviour, IAIInputManager
    {
        bool _arrived = false;
        bool _isStart = true;
        public Vector3 _direction;
        int _forwardDirection = 1;
        int _sideDirection = 0;
        ITransferInputToMovement _transferDataManager;
        IObjectMover _moveObjectComponent;
        IAIDirectionSettingManager _aiDirectionSettingComponent;
        private void GetComponents()
        {
            if (!_isStart)
                return;
            _transferDataManager = this.GetComponent<TransferInputToMovement>();
            _moveObjectComponent = this.GetComponent<ObjectMover>();
            _aiDirectionSettingComponent = this.gameObject.GetComponent<AIDirectionSettingManager>(); 
            _isStart = false;
        }
        public void ManageAIInputData()
        {
            GetComponents();
            RaycastHit hit;
            if (!_arrived && Physics.Raycast(this.transform.position, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.gameObject.tag == "GridCell")
                {
                    _direction = hit.collider.gameObject.GetComponent<GridCell>().GetDirection();
                }
            }
            _aiDirectionSettingComponent.SetDirections(ref _forwardDirection, ref _sideDirection, _moveObjectComponent.GetSpeed(), _direction);
            _transferDataManager.TransferInputsToMovementData(_forwardDirection, false);
            _transferDataManager.TransferInputsToMovementData(this.transform.forward, _sideDirection * this.transform.right, new Vector3(0, _sideDirection, 0));
        }
        public Vector3 GetCurrentDirection()
        {
            return _direction;
        }
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
        public void SetArrived(bool arrived)
        {
            _arrived = arrived;
        }
    }
}