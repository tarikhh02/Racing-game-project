using Assets.Scripts.GridCellManager;
using Race_game_project.AIPathFinderManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.PathCleaningManager
{
    public class PathClearingManager : MonoBehaviour, IPathClearingManager
    {
        [SerializeField] 
        Material defaultCellColor;
        public void ClearPath(ref List<KeyValuePair<IGridCell, Vector3>> path)
        {
            if(path.Count == 0) 
                return;
            foreach(var pathCell in path)
            {
                pathCell.Key.RemoveCarThatVillPass(this.GetComponent<AIShortestPathFinder>());
                pathCell.Key.GetGameObject().GetComponent<MeshRenderer>().material = defaultCellColor;
                pathCell.Key.GetGameObject().GetComponent<MeshRenderer>().enabled = false;
            }
            path.Clear();
        }
    }
}