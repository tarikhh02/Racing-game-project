using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.CellUnwalkableMaker
{
    public interface ICellUnwalkableMarker
    {
        public void MarkCellAsUnwalkabe(ref List<List<IGridCell>> grid);

    }
}