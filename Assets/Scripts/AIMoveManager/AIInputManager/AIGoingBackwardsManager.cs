using Race_game_project.AICarMovement;
using System.Collections;
using UnityEngine;

namespace Race_game_project.AIBackwardsGoingManagement
{
    public class AIGoingBackwardsManager : MonoBehaviour, IAIGoingBackwardsManager
    {
        public void GoBackwards(ref bool canInitializePath, ref float forwardDirection, ref int sideDirection, IAICarMovement aICarMovement)
        {
            forwardDirection = -1;
            sideDirection = 0;
            aICarMovement.SetNewPath();
            canInitializePath = false;
        }
    }
}