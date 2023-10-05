using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using UnityEditor;
using UnityEngine;

namespace Race_game_project.PowerUpsManager
{
    [CreateAssetMenu(fileName = "ThrotleIncrementPowerupData", menuName="Race_game_project.PowerUps/ThrotlePowerUp", order = 1)]
    public class ThrotleIncrementPowerUp : PowerUpBase
    {
        public ThrotleIncrementPowerUp(ISpeedManager speedManager, IObjectMover moveObjComponent) : base(speedManager, moveObjComponent)
        {
            throtleIncrement = 0.003f;
        }
    }
}