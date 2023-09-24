using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.WalkableCellsFinderManager
{
    public interface IWalklableCellsFinder
    {
        public List<IGridCell> FindWalkableCells(int height, int width, Vector3 gridPosition, List<IGridCell> cellsToChooseFrom, int x, int y, float scale);
    }

}