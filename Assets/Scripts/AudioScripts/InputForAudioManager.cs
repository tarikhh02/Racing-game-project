using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using System;
using UnityEngine;

namespace Race_game_project.AudioInputManagement
{
    public class InputForAudioManager : MonoBehaviour, IInputForAudioManager
    {
        ISpeedManager _speedManager;
        IObjectMover _objectMover;
        bool _hasEngagedBraking = false;
        private void Awake()
        {
            _speedManager = this.GetComponent<SpeedManager>();
            _objectMover = this.GetComponent<ObjectMover>();
        }
        public void GetInputForAudio(ref Race_game_project.AudioScripts.State _nextState, AudioSource braking, AudioSource spinningWheels)
        {
            int speed = (int)(Math.Abs(_objectMover.GetSpeed()) * 100);
            if (_speedManager.GetIsBreaking())
            {
                if (!_hasEngagedBraking)
                {
                    _hasEngagedBraking = true;
                    braking.Play();
                }
            }
            else
                _hasEngagedBraking = false;
            if (speed == 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
                spinningWheels.Play();
            if (speed == 0 || _speedManager.GetIsLoweringSpeed())
                _nextState = Race_game_project.AudioScripts.State.Idle;
            else if (_speedManager.GetHasAchievedMaximumSpeed())
                _nextState = Race_game_project.AudioScripts.State.MaxSpeed;
            else
                _nextState = Race_game_project.AudioScripts.State.Throttle;

        }
    }
}