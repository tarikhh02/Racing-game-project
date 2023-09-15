using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GridCellManager;

namespace Assets.Scripts.PathFindingManager
{
    public interface ISetCostFromEndToRest
    {
        public void SetCostFromEnd(ref List<List<IGridCell>> grid, int x, int y, int cost);
    }
}