using Race_game_project.AICarMovement;
using System.Collections;
using UnityEngine;

namespace Race_game_project.AIBackwardsGoingManagement
{
    public interface IAIGoingBackwardsManager
    {
        void GoBackwards(ref bool canInitializePath, ref float forwardDirection, ref int sideDirection, IAICarMovement aICarMovement);
    }
}