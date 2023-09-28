using Race_game_project.CollisionForUIHandler;
using Race_game_project.ProgresCalculatingManager;
using Race_game_project.SpeedWritingManager;
using Race_game_project.TimerManager;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

namespace Race_game_project.UIImplementationManager
{
    public class ManageUI : MonoBehaviour, IManageUI
    {
        [SerializeField]
        Transform start;
        [SerializeField]
        Transform halfTrack;
        [SerializeField]
        Transform secondStart;
        [SerializeField]
        Transform end;
        [SerializeField]
        TextMeshProUGUI position;
        [SerializeField]
        bool isPlayer = false;
        int _position;
        IProgressCalculator _progressCalcManager;
        ITimerManager _timerManager;
        ISpeedWriter _speedWritingManager;
        ICollisionHandler _collisionHandler;
        private void Awake()
        {
            if(isPlayer)
                _speedWritingManager = GetComponent<SpeedWriter>();
            _timerManager = GetComponent<TimerManager.TimerManager>();
            _progressCalcManager = GetComponent<ProgressCalculator>();
            _collisionHandler = GetComponent<CollisionHandler>();
        }
        private void Update()
        {
            if (isPlayer)
            {
                _speedWritingManager.WriteSpeed();
                _timerManager.WriteTime();
            }
            _progressCalcManager.CalculateProgress(start, halfTrack, secondStart, end, _collisionHandler.GetIsGoingBackwards(), _collisionHandler.GetHasPassedHalfTrack(), isPlayer);
        }
        public int GetProgress()
        {
            return _progressCalcManager.GetProgress();
        }
        public int GetLap()
        {
            return _timerManager.GetLap();
        }
        public void SetPosition(int position)
        {
            _position = position;
            this.position.text = "Position: " + position;
        }
        public bool IsPlayer()
        {
            return isPlayer;
        }
    }
}