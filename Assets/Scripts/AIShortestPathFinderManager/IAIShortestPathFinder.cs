using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.AIPathFinderManager
{
    public interface IAIShortestPathFinder
    {
        public void FindShortestPath(GameObject gridComponent, float previousDistance, bool isStart = false);
        public int GetId();
        public List<KeyValuePair<IGridCell, Vector3>> GetPath();
    }
}