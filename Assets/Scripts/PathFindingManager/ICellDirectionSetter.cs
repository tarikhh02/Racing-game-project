using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PathFindingManager
{
    public interface ICellDirectionSetter
    {
        public void SetEachCellDirection(ref List<List<IGridCell>> grid, GameObject endPoint);
    }
}