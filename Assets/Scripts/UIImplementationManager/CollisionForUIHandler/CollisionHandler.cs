using Race_game_project.TimerManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.CollisionForUIHandler
{
    public class CollisionHandler : MonoBehaviour, ICollisionHandler
    {
        bool _hasPassedHalfTrack = false;
        bool _goingBackwards = false;
        ITimerManager _timerManager;
        private void Awake()
        {
            _timerManager = GetComponent<TimerManager.TimerManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("HalfTrack"))
            {
                CheckIfGoingBackwards(true);
            }
            else if (other.CompareTag("End"))
            {
                CheckIfGoingBackwards(false);
            }
            else if (other.CompareTag("Start"))
            {
                ResetGoingBackward(false);
            }
            else if (other.CompareTag("SecondStart"))
            {
                ResetGoingBackward(true);
            }
        }

        private void ResetGoingBackward(bool condition)
        {
            if (_hasPassedHalfTrack == condition)
                _goingBackwards = false;
        }

        private void CheckIfGoingBackwards(bool condition)
        {
            if (_hasPassedHalfTrack == condition)
            {
                _goingBackwards = true;
            }
            else
            {
                _goingBackwards = false;
                _hasPassedHalfTrack = condition;
                if (!condition)
                    _timerManager.ResetTimer();
            }
        }
        public bool GetHasPassedHalfTrack()
        {
            return _hasPassedHalfTrack;
        }
        public bool GetIsGoingBackwards()
        {
            return _goingBackwards;
        }
    }
}