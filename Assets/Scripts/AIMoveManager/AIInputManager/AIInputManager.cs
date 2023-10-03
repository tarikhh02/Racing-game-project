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
        Vector3 _startCarPos = new Vector3();
        Quaternion _startCarRot = Quaternion.identity;
        float _forwardDirection = 1;
        float _timer = 1;
        int _sideDirection = 0;
        ITransferInputToMovement _transferDataManager;
        IObjectMover _moveObjectComponent;
        IAIDirectionSettingManager _aiDirectionSettingComponent;
        IAIShortestPathFinder _aiPathFinder;
        IAICarMovement _aiCarMovement;
        private void Awake()
        {
            _startCarPos = this.transform.position;
            _startCarRot = this.transform.rotation;
            StartCoroutine(nameof(TimerCounter));
        }
        private void Update()
        {
            if (this.transform.position.y < -1f)
            {
                this.transform.position = _startCarPos;
                this.transform.rotation = _startCarRot;
                _direction = Vector3.zero;
                _moveObjectComponent.GetSpeed() = 0;
                _isStuck = false;
                _aiCarMovement.SetNewPath();
            }
        }
        private void GetComponents()
        {
            if (!_isStart)
                return;
            _transferDataManager = this.GetComponent<TransferInputToMovement>();
            _moveObjectComponent = this.GetComponent<ObjectMover>();
            _aiDirectionSettingComponent = this.gameObject.GetComponent<AIDirectionSettingManager>();
            _aiPathFinder = this.gameObject.GetComponent<AIShortestPathFinder>();
            _aiCarMovement = this.gameObject.GetComponent<AICarMovement>();
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
                Vector3 frontPosition = this.transform.position + Vector3.up * 0.2f;
                listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition));
                listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition + this.transform.right * 0.25f));
                listOfVisibleToCell.Add(GetCellsWithCarSignature(frontPosition - this.transform.right * 0.25f));
                if (_timer == 5 || _isStuck)
                {
                    _timer = 0;
                    if (Vector3.Distance(this.transform.position, _lastCarPosition) <= 1f)
                    {
                        _isStuck = true;
                        _canInitializePath = GoBackwards();
                    }
                    else
                    {
                        _isStuck = false;
                        _lastCarPosition = this.transform.position;
                    }
                }
                if (listOfVisibleToCell.Where(c => c != null).Count() == 0)
                {
                    _canInitializePath = GoBackwards();
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
                    _aiCarMovement.SetNewPath();
                }
            }
            if (_canInitializePath)
                _aiDirectionSettingComponent.SetDirections(ref _forwardDirection, ref _sideDirection, _moveObjectComponent.GetSpeed(), _direction, _moveObjectComponent.GetMaxMovementSpeed());
            _transferDataManager.TransferInputsToMovementData(_forwardDirection, false);
            _transferDataManager.TransferInputsToMovementData(this.transform.forward, _sideDirection * this.transform.right, new Vector3(0, _sideDirection, 0));
        }
        private bool GoBackwards()
        {
            _forwardDirection = -1;
            _sideDirection = 0;
            _aiCarMovement.SetNewPath();
            return false;
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