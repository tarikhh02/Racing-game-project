using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using UnityEditor;
using UnityEngine;

namespace Race_game_project.PowerUpsManager
{
    [CreateAssetMenu(fileName = "SpeedIncreasePowerUpData", menuName = "Race_game_project.PowerUps/MaxSpeedIncrementPowerUp", order = 1)]
    public class MaxSpeedIncreasePowerUp : PowerUpBase
    {
        public MaxSpeedIncreasePowerUp(ISpeedManager _speedManager, IObjectMover _moveObjComponent) : base(_speedManager, _moveObjComponent)
        {
            speedIncrement = 1;
        }
    }
}