using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Race_game_project.ListSortingManager
{
    public interface IListByCostSorter
    {
        public void SortList(ref List<IGridCell> cellListToSort);
    }
}