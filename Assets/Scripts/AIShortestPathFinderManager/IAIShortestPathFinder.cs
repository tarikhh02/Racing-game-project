using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.AIPathFinderManager
{
    public interface IAIShortestPathFinder
    {
        public void FindShortestPath(GameObject gridComponent, float previousDistance);
        public int GetId();
    }
}