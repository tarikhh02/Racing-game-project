using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.ListSortingManager
{
    public class ListByCostSorter : MonoBehaviour, IListByCostSorter
    {
        public void SortList(ref List<IGridCell> cellListToSort)
        {
            for (int i = 0; i < cellListToSort.Count; i++)
            {
                for (int j = 0; j < cellListToSort.Count - 1; j++)
                {
                    if (cellListToSort[j].GetCost() > cellListToSort[j + 1].GetCost())
                    {
                        var tempCell = cellListToSort[j + 1];
                        cellListToSort[j + 1] = cellListToSort[j];
                        cellListToSort[j] = tempCell;
                    }
                }
            }
        }
    }
}