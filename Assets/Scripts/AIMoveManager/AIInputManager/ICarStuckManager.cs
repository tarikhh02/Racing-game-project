using Assets.Scripts.GridCellManager;
using Race_game_project.AICarMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.ManagerIfCarIsStuck
{
    public interface ICarStuckManager
    {
        void ManageCarIfStuck(ref List<IGridCell> listOfVisibleToCell, ref float timer, ref bool canInitializePath, ref bool isStuck, ref float forwardDirection, ref int sideDirection, IAICarMovement aiCarMovement);
    }
}