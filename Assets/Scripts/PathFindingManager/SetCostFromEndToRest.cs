using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Assets.Scripts.GridCellManager;

namespace Assets.Scripts.PathFindingManager
{
    [ExecuteInEditMode]
    public class SetCostFromEndToRest : MonoBehaviour, ISetCostFromEndToRest
    {
        Queue<IGridCell> _nextCellsToCheck = new Queue<IGridCell>();
        public void SetCostFromEnd(ref List<List<IGridCell>> grid, int x, int y, int cost)
        {
            if(cost == 0)
            {
                grid[y][x].SetCostIncrementValue(0);
                grid[y][x].SetCost(cost);
            }
            if (x < grid[y].Count - 1 && !grid[y][x + 1].GetChecked())
            {
                grid[y][x + 1].SetCost(cost);
                _nextCellsToCheck.Enqueue(grid[y][x + 1]);
            }
            if (x > 0 && !grid[y][x - 1].GetChecked())
            {
                grid[y][x - 1].SetCost(cost);
                _nextCellsToCheck.Enqueue(grid[y][x - 1]);
            }
            if (y < grid.Count - 1 && !grid[y + 1][x].GetChecked())
            {
                grid[y + 1][x].SetCost(cost);
                _nextCellsToCheck.Enqueue(grid[y + 1][x]);
            }
            if (y > 0 && !grid[y - 1][x].GetChecked())
            {
                grid[y - 1][x].SetCost(cost);
                _nextCellsToCheck.Enqueue(grid[y - 1][x]);
            }
            if (_nextCellsToCheck.Count != 0)
            {
               var gridCell = _nextCellsToCheck.Dequeue();
                this.SetCostFromEnd(ref grid, gridCell.GetX(), gridCell.GetY(), gridCell.GetCost());
            }
        }
    }
}