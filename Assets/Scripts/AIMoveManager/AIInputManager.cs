using Assets.Scripts.GridCellManager;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.MovementManager;
using Assets.Scripts.TransferingInputsToMovementManager;
using Race_game_project.AIPathFinderManager;
using Racing_game_project.AIDirectionSetter;
using System;
using System.Collections;
using System.Linq;
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
        IAIShortestPathFinder _aiPathFinder;
        private void GetComponents()
        {
            if (!_isStart)
                return;
            _transferDataManager = this.GetComponent<TransferInputToMovement>();
            _moveObjectComponent = this.GetComponent<ObjectMover>();
            _aiDirectionSettingComponent = this.gameObject.GetComponent<AIDirectionSettingManager>();
            _aiPathFinder = this.gameObject.GetComponent<AIShortestPathFinder>();
            _isStart = false;
        }
        public void ManageAIInputData()
        {
            GetComponents();
            if (!_arrived)
            {
                Vector3 colliderPosition = this.transform.position + this.transform.forward * this.transform.localScale.z * 2;
                Collider[] colliders = Physics.OverlapBox(colliderPosition, new Vector3(2, 0.5f, 1f), 
                    Quaternion.Euler(0f, this.transform.rotation.y + Vector3.SignedAngle(this.transform.forward, _direction, Vector3.up), 0f)).Where(s => s.CompareTag("GridCell")).ToArray();
                foreach (Collider collider in colliders)
                {
                    foreach (var car in collider.gameObject.GetComponent<GridCell>().GetListOfCarsThatWillPass())
                    {
                        if (this.GetComponent<AIShortestPathFinder>().GetId() == car.Key.GetId())
                        {
                            var cell = collider.gameObject.GetComponent<GridCell>();
                            var path = _aiPathFinder.GetPath();
                            foreach (var pathCell in path)
                            {
                                if (pathCell.Key.GetX() == cell.GetX() && pathCell.Key.GetY() == cell.GetY())
                                {
                                    _direction = pathCell.Value;
                                }
                            }
                            break;
                        }
                    }
                }
                _aiDirectionSettingComponent.SetDirections(ref _forwardDirection, ref _sideDirection, _moveObjectComponent.GetSpeed(), _direction);
                _transferDataManager.TransferInputsToMovementData(_forwardDirection, false);
                _transferDataManager.TransferInputsToMovementData(this.transform.forward, _sideDirection * this.transform.right, new Vector3(0, _sideDirection, 0));
            }
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