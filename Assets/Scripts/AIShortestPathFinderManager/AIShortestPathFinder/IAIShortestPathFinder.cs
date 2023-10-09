using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Race_game_project.AIPathFinderManager
{
    public interface IAIShortestPathFinder
    {
        public void FindShortestPath(GameObject gridComponent, float previousDistance, bool isStart = false);
        public List<KeyValuePair<IGridCell, Vector3>> GetPath();
        public GameObject GetGameObject();
        public System.Guid GetId();
    }
}