using System.Collections;
using UnityEngine;

namespace Race_game_project.PowerUpsManager
{
    public interface IPowerUpImplementation
    {
        public void ImplementPowerUpValues();
        public void ResetPowerUpValues();
    }
}