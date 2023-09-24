using Assets.Scripts.GridCellManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.StartCellFinder
{
    public interface IStartCellFinder
    {
        public void GetStartCell(ref IGridCell startCell);
    }
}