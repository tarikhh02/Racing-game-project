using Assets.Scripts.GridInitializer;
using Assets.Scripts.GridCellManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Assets.Scripts.PathFindingManager
{
    public class CellCostSetter : MonoBehaviour, ICellCostSetter
    {
        IGridInitialization _gridInitComponent;
        IPathFinder _pathFinder;
        private void Awake()
        {
            _gridInitComponent = this.GetComponent<GridInitialization>();
            _pathFinder = this.GetComponent<PathFinder>();
        }
        public void SetCellCosts()
        {
            Tuple<int, int> end = _pathFinder.GetEndIndex();
            ref List<List<IGridCell>> grid = ref _gridInitComponent.GetGrid();
            grid[end.Item1][end.Item2].SetCost(0);
            for (int y = end.Item2; y < grid.Count; y++)
            {
                SetXAxis(end, ref grid, y);
                if (y < grid.Count - 1)
                    grid[y + 1][end.Item1].SetCost(grid[y][end.Item1].GetCost() + 1);
            }
            for (int y = end.Item2 - 1; y >= 0; y--)
            {
                if (y < grid.Count)
                    grid[y][end.Item1].SetCost(grid[y + 1][end.Item1].GetCost() + 1);
                SetXAxis(end, ref grid, y);
            }
        }

        private void SetXAxis(Tuple<int, int> end, ref List<List<IGridCell>> grid, int y)
        {
            for (int x = end.Item1 + 1; x < grid.Count; x++)
            {
                if (x != end.Item1 || y != end.Item2)
                    grid[y][x].SetCost(grid[y][x - 1].GetCost() + 1);
            }
            for (int x = end.Item1 - 1; x >= 0; x--)
            {
                if (x != end.Item1 || y != end.Item2)
                    grid[y][x].SetCost(grid[y][x + 1].GetCost() + 1);
            }
        }
    }
}