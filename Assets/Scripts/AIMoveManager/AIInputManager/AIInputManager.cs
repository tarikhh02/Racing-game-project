using Assets.Scripts.GridCellManager;
using Assets.Scripts.MovementManager;
using Assets.Scripts.TransferingInputsToMovementManager;
using Racing_game_project.AIDirectionSetter;
using Race_game_project.AICarMovement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using Race_game_project.VisibleCellFinder;
using Race_game_project.AIBackwardsGoingManagement;
using Race_game_project.ManagerIfCarIsStuck;
using Race_game_project.UIImplementationManager;

namespace Racing_game_project.AIInputManager
{
    public class AIInputManager : MonoBehaviour, IAIInputManager
    {
        bool _arrived = false;
        bool _isStart = true;
        bool _isStuck = false;
        bool _isRaceFinished = false;
        public Vector3 _direction;
        Vector3? _carUnwalkableStartPos = null;
        Vector3 _startCarPos = new Vector3();
        Quaternion _startCarRot = Quaternion.identity;
        float _forwardDirection = 1;
        float _timer = 1;
        int _sideDirection = 0;
        ITransferInputToMovement _transferDataManager;
        IObjectMover _moveObjectComponent;
        IAIDirectionSettingManager _aiDirectionSettingComponent;
        IAICarMovement _aiCarMovement;
        IVIsibleCellFinderManager _visibleCellFinderManager;
        IAIGoingBackwardsManager _backwardsGoingManager;
        ICarStuckManager _carStuckManager;
        IManageUI _uiManager;
        private void Awake()
        {
            _startCarPos = this.transform.position;
            _startCarRot = this.transform.rotation;
            StartCoroutine(nameof(TimerCounter));
        }
        private void Update()
        {
            if (this.transform.position.y < -1f 
                || (_carUnwalkableStartPos != null && Vector3.Distance(_carUnwalkableStartPos.Value, this.transform.position) > 15f))
            {
                ResetCar();
            }
        }

        private void ResetCar()
        {
            this.transform.position = _startCarPos;
            this.transform.rotation = _startCarRot;
            _direction = Vector3.zero;
            _moveObjectComponent.GetSpeed() = 0;
            _isStuck = false;
            _aiCarMovement.SetIsSecondHalfOfGrid(false);
            _aiCarMovement.SetNewPath();
            _uiManager.ResetTracking();
        }

        private void GetComponents()
        {
            if (!_isStart)
                return;
            _transferDataManager = this.GetComponent<TransferInputToMovement>();
            _moveObjectComponent = this.GetComponent<ObjectMover>();
            _aiDirectionSettingComponent = this.gameObject.GetComponent<AIDirectionSettingManager>();
            _aiCarMovement = this.gameObject.GetComponent<AICarMovement>();
            _visibleCellFinderManager = this.gameObject.GetComponent<VisibleCellFinderManager>();
            _backwardsGoingManager = this.gameObject.GetComponent<AIGoingBackwardsManager>();
            _carStuckManager = this.gameObject.GetComponent<CarStuckManager>();
            _uiManager = this.GetComponent<ManageUI>();
            _isStart = false;
        }
        public void ManageAIInputData()
        {
            bool canInitializePath = true;
            GetComponents();
            if (!_arrived)
            {
                bool hasFoundCell = false;
                List<IGridCell> listOfVisibleToCell = new List<IGridCell>();
                _carStuckManager.ManageCarIfStuck(ref listOfVisibleToCell,ref _timer, ref canInitializePath, ref _isStuck, ref _forwardDirection, ref _sideDirection, _aiCarMovement);
                if (listOfVisibleToCell.Where(c => c != null).Count() == 0)
                {
                    _backwardsGoingManager.GoBackwards(ref canInitializePath, ref _forwardDirection, ref _sideDirection, _aiCarMovement);
                    if(_carUnwalkableStartPos == null)
                        _carUnwalkableStartPos = this.transform.position;
                }
                else
                {
                    _carUnwalkableStartPos = null;
                }
                _visibleCellFinderManager.FindCells(listOfVisibleToCell, ref _direction, ref hasFoundCell);
                if (!hasFoundCell && listOfVisibleToCell.Where(c => c != null).Count() > 0 && !_isStuck)
                    _aiCarMovement.SetNewPath();
            }
            if (canInitializePath && !_isRaceFinished)
                _aiDirectionSettingComponent.SetDirections(ref _forwardDirection, ref _sideDirection, _moveObjectComponent.GetSpeed(), _direction, _moveObjectComponent.GetMaxMovementSpeed());
            _transferDataManager.TransferInputsToMovementData(_forwardDirection, false);
            _transferDataManager.TransferInputsToMovementData(this.transform.forward, _sideDirection * this.transform.right, new Vector3(0, _sideDirection, 0));
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
        public float GetSideDirection()
        {
            return _sideDirection;
        }
        public void SetSideDirection(int value)
        {
            _sideDirection = value;
        }
        public void SetForwardDirection(float value)
        {
            _forwardDirection = value;
        }
        public void FinishRace()
        {
            _isRaceFinished = true;
        }
    }
}