using Race_game_project.AIPathFinderManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.AICarMovement
{
    public interface IAICarMovement
    {
        public void SetIsSecondHalfOfGrid(bool isSecondHalf);
        public void SetNewPath();
    }
}