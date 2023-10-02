using Assets.Scripts.GridCellManager;
using Assets.Scripts.MovementManager;
using Assets.Scripts.TransferingInputsToMovementManager;
using Race_game_project.AIPathFinderManager;
using Racing_game_project.AIDirectionSetter;
using Race_game_project.AICarMovement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Racing_game_project.AIInputManager
{
    public class AIInputManager : MonoBehaviour, IAIInputManager
    {
        bool _canInitializePath = true;
        bool _arrived = false;
        bool _isStart = true;
        public Vector3 _direction;
        Vector3 _lastUnwalkableCellPos = Vector3.zero;
        Vector3 _lastSeenDirection = Vector3.zero;
        float _forwardDirection = 1;
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
                bool hasFoundCell = false;
                List<IGridCell> listOfCarsAssignedToCell = new List<IGridCell>();
                Vector3 frontPosition = this.transform.position + this.transform.forward * this.transform.localScale.z / 2;
                listOfCarsAssignedToCell.Add(GetCellsWithCarSignature(frontPosition));
                listOfCarsAssignedToCell.Add(GetCellsWithCarSignature(frontPosition + this.transform.right * this.transform.localScale.x / 2));
                listOfCarsAssignedToCell.Add(GetCellsWithCarSignature(frontPosition - this.transform.right * this.transform.localScale.x / 2));
                if(listOfCarsAssignedToCell.Where(c => c != null).Count() == 0)
                {
                    if(GetCellsWithCarSignature(frontPosition * 2) == null)
                    {
                        _canInitializePath = false;
                        _forwardDirection = -1;
                        _sideDirection = 0;
                    }
                    else
                    {
                        _canInitializePath = true;
                        _forwardDirection = 1;
                    }
                    this.gameObject.GetComponent<AICarMovement>().SetNewPath();
                }
                /*if (Vector3.Distance(frontPosition, _lastUnwalkableCellPos) <= 1f && listOfCarsAssignedToCell.Where(c => c != null).Count() == 0)
                {
                    _canInitializePath = false;
                    _forwardDirection = -1;
                    _sideDirection = 0;
                    this.gameObject.GetComponent<AICarMovement>().SetNewPath();
                }*/
                foreach (var cell in listOfCarsAssignedToCell)
                {
                    if (cell == null)
                        continue;
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
            if(_canInitializePath)
                _aiDirectionSettingComponent.SetDirections(ref _forwardDirection, ref _sideDirection, _moveObjectComponent.GetSpeed(), _direction, _moveObjectComponent.GetMaxMovementSpeed());
            _transferDataManager.TransferInputsToMovementData(_forwardDirection, false);
            _transferDataManager.TransferInputsToMovementData(this.transform.forward, _sideDirection * this.transform.right, new Vector3(0, _sideDirection, 0));
        }
        private IGridCell GetCellsWithCarSignature(Vector3 position)
        {
            RaycastHit hit;
            Debug.DrawRay(position, -this.transform.up, Color.red, 2f);
            if (Physics.Raycast(position, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.CompareTag("GridCell"))
                {
                    return hit.collider.GetComponent<GridCell>();
                }
                else if(hit.collider.CompareTag("Unwalkable"))
                {
                    _lastUnwalkableCellPos = hit.collider.transform.position;
                }
            }
            return null;
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