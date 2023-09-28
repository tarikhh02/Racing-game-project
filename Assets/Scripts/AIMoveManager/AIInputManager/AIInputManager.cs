using Assets.Scripts;
using Assets.Scripts.GridCellManager;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.MovementManager;
using Assets.Scripts.TransferingInputsToMovementManager;
using Race_game_project.AIPathFinderManager;
using Racing_game_project.AIDirectionSetter;
using Race_game_project.AICarMovement;
using System;
using System.Collections;
using System.Collections.Generic;
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
            bool canInitializePath = true;
            GetComponents();
            if (!_arrived)
            {
                bool hasFoundCell = false;
                List<IGridCell> listOfCarsAssignedToCell = new List<IGridCell>();
                Vector3 frontPosition = this.transform.position + this.transform.forward * this.transform.localScale.z / 2;
                listOfCarsAssignedToCell.Add(GetCellsWithCarSignature(frontPosition));
                //listOfCarsAssignedToCell.Add(GetCellsWithCarSignature(frontPosition + this.transform.right * this.transform.localScale.x / 2));
                //listOfCarsAssignedToCell.Add(GetCellsWithCarSignature(frontPosition - this.transform.right * this.transform.localScale.x / 2));
                foreach (var cell in listOfCarsAssignedToCell)
                {
                    if (cell == null)
                        continue;
                    if(cell.GetGameObject().CompareTag("Unwalkable"))
                    {
                        canInitializePath = false;
                        _sideDirection = 0;
                        _forwardDirection = -1;
                        continue;
                    }
                    foreach (var car in cell.GetListOfCarsThatWillPass())
                    {
                        if (this.GetComponent<AIShortestPathFinder>().GetId() == car.Key.GetId())
                        {
                            var path = _aiPathFinder.GetPath();
                            foreach (var pathCell in path)
                            {
                                if (pathCell.Key.GetX() == cell.GetX() && pathCell.Key.GetY() == cell.GetY())
                                {
                                    _direction = pathCell.Value;
                                    hasFoundCell = true;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    if (hasFoundCell)
                        break;
                }
                if (!hasFoundCell && listOfCarsAssignedToCell.Where(c => c != null).Count() > 0)
                {
                    this.gameObject.GetComponent<AICarMovement>().SetNewPath();
                }
            }
            if(canInitializePath)
                _aiDirectionSettingComponent.SetDirections(ref _forwardDirection, ref _sideDirection, _moveObjectComponent.GetSpeed(), _direction);
            _transferDataManager.TransferInputsToMovementData(_forwardDirection, false);
            _transferDataManager.TransferInputsToMovementData(this.transform.forward, _sideDirection * this.transform.right, new Vector3(0, _sideDirection, 0));
        }
        private IGridCell GetCellsWithCarSignature(Vector3 position)
        {
            RaycastHit hit;
            if ((Physics.Raycast(position, -this.transform.up, out hit, 0.5f) && (hit.collider.CompareTag("GridCell") || hit.collider.CompareTag("Unwalkable"))))
            {
                return hit.collider.GetComponent<GridCell>();
            }
            else 
            { 
                return null; 
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