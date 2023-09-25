using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.CellAdder
{
    public interface ICellAdder
    {
        public void AddCellToPath(ref List<KeyValuePair<IGridCell, Vector3>> path, ref IGridCell pathCell, IGridCell currentCell, Material material);
    }
}