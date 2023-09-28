using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.PathCleaningManager
{
    public interface IPathClearingManager
    {
        public void ClearPath(ref List<KeyValuePair<IGridCell, Vector3>> path);
    }
}