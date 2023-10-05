using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using System;
using System.Collections;
using UnityEngine;

namespace Race_game_project.PowerUpsManager
{
    [CreateAssetMenu(fileName = "PowerUpData", menuName = "Race_game_project.PowerUpBase", order = 1)]
    public abstract class PowerUpBase : ScriptableObject, IPowerUpImplementation
    {
        public float speedIncrement = 0;
        public float breakForceIncrement = 0;
        public float throtleIncrement = 0;
        ISpeedManager _speedManager;
        IObjectMover _moveObject;
        public PowerUpBase(ISpeedManager speedManager, IObjectMover moveObject)
        {
            _speedManager = speedManager;
            _moveObject = moveObject;
        }
        public virtual void ImplementPowerUpValues()
        {
            SetValues(1);
        }

        public virtual void ResetPowerUpValues()
        {
            SetValues(-1);
            ResetSpeed();
        }

        private void ResetSpeed()
        {
            if (_moveObject.GetSpeed() > _moveObject.GetMaxMovementSpeed())
            {
                _moveObject.GetSpeed() -= 0.2f;
                ResetSpeed();
            }
        }
        private void SetValues(float signDeterminationValue)
        {
            _moveObject.GetMaxMovementSpeed() += speedIncrement * signDeterminationValue;
            _speedManager.AddToThrotle(throtleIncrement * signDeterminationValue);
            _speedManager.AddToBreakingForce(breakForceIncrement * signDeterminationValue);
        }
    }
}