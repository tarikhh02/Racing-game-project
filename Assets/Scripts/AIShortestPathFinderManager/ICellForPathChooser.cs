using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.CellForPathChooserComponent
{
    public interface ICellForPathChooser
    {
        public IGridCell ChooseCellForPath(ref List<IGridCell> cellsToChoose, ref float previousDistance, float scale, float speed);
    }
}