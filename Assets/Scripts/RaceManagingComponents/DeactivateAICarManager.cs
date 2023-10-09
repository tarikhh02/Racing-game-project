using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using Race_game_project.UIImplementationManager;
using Racing_game_project.AIInputManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.DeactivateCarManager
{
    public class DeactivateAICarManager : MonoBehaviour, IDeactivateCarManager
    {
        public void DeactivateCar(ManageUI car)
        {
            this.gameObject.SetActive(false);
        }
    }
}