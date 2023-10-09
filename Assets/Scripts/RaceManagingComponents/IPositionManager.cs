using System.Collections.Generic;
using Race_game_project.UIImplementationManager;
using UnityEngine;

namespace Race_game_project.PositionManager
{
    public interface IPositionManager
    {
        public void ManagePositions(List<ManageUI> listOfAllCars);
    }
}