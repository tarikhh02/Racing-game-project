using Assets.Scripts.GridCellManager;
using Assets.Scripts.MovementManager;
using Assets.Scripts.TransferingInputsToMovementManager;
using Race_game_project.AIPathFinderManager;
using Racing_game_project.AIDirectionSetter;
using Race_game_project.AICarMovement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System;

namespace Racing_game_project.AIInputManager
{
    public class AIInputManager : MonoBehaviour, IAIInputManager
    {
        bool _arrived = false;
        bool _isStart = true;
        bool _isStuck = false;
        public Vector3 _direction;
        Vector3 _lastCarPosition = Vector3.zero;
        float _forwardDirection = 1;
        float _timer = 0;
        int _sideDirection = 0;
        ITransferInputToMovement _transferDataManager;
        IObjectMover _moveObjectComponent;
        IAIDirectionSettingManager _aiDirectionSettingComponent;
        IAIShortestPathFinder _aiPathFinder;
        private void Awake()
        {
            StartCoroutine(nameof(TimerCounter));
        }
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
            bool _canInitializePath = true;
            GetComponents();
            if (!_arrived)
            {
                bool hasFoundCell = false;
                List<IGridCell> listOfVisibleToCell = new List<IGridCell>();
                Vector3 frontPosition = this.transform.position + this.transform.forward * this.transform.localScale.z / 2;
                listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition));
                listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition + this.transform.right * this.transform.localScale.x / 2));
                listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition - this.transform.right * this.transform.localScale.x / 2));
                if(_timer >= 5 || _isStuck)
                {
                    if (Vector3.Distance(this.transform.position, _lastCarPosition) <= 0.5f)
                    {
                        _timer = 0;
                        _canInitializePath = false;
                        _forwardDirection = -1;
                        _sideDirection = 0;
                        this.gameObject.GetComponent<AICarMovement>().SetNewPath();
                        _isStuck = true;
                    }
                    else
                    {
                        _isStuck = false;
                        _lastCarPosition = this.transform.position;
                    }
                }
                if (listOfVisibleToCell.Where(c => c != null).Count() == 0)
                {
                    _canInitializePath = false;
                    _forwardDirection = -1;
                    _sideDirection = 0;
                    this.gameObject.GetComponent<AICarMovement>().SetNewPath();
                }
                
                foreach (var cell in listOfVisibleToCell)
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
                if (!hasFoundCell && listOfVisibleToCell.Where(c => c != null).Count() > 0 && !_isStuck)
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
            if (Physics.Raycast(position, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.CompareTag("GridCell"))
                {
                    return hit.collider.GetComponent<GridCell>();
                }
                //else if(hit.collider.CompareTag("Unwalkable"))
                //{
                //   _lastCarPosition = hit.collider.transform.position;
                //}
            }
            return null;
        }
        private IEnumerator TimerCounter()
        {
            yield return new WaitForSeconds(1f);
            _timer += 1f;
            StartCoroutine(nameof(TimerCounter));
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