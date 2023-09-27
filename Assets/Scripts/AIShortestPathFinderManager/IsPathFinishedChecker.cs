using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Race_game_project.PathFinishChecker
{
    public class IsPathFinishedChecker : MonoBehaviour, IIsPathFinishedChecker
    {
        public bool IsPathFinished(IGridCell pathCell, Vector3 endPosition, int pathCount)
        {
            if (pathCount > 1)
                return true;
            Collider[] colliders = Physics.OverlapBox(endPosition, new Vector3(4f, 0.5f, 0.5f)).Where(s => s.CompareTag("GridCell")).ToArray();
            foreach (var collider in colliders) 
            {
                if (pathCell.GetX() == collider.gameObject.GetComponent<GridCell>().GetX() && pathCell.GetY() == collider.gameObject.GetComponent<GridCell>().GetY())
                {
                    return true;
                }
            }
            return false;
        }
    }
}