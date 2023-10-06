using Assets.Scripts.GridCellManager;
using Race_game_project.AIPathFinderManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.VisibleCellFinder
{
    public interface IVIsibleCellFinderManager
    {
        void FindCells(List<IGridCell> listOfVisibleToCell, ref Vector3 _direction, ref bool hasFoundCell);
    }
}