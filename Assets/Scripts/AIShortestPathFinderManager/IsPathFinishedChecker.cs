using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Race_game_project.PathFinishChecker
{
    public class IsPathFinishedChecker : MonoBehaviour, IIsPathFinishedChecker
    {
        public bool IsPathFinished(IGridCell pathCell, Vector3 endPosition)
        {
            Collider[] colliders = Physics.OverlapBox(endPosition, new Vector3(0.0001f, 0.5f, 0.0001f)).Where(s => s.CompareTag("GridCell")).ToArray();
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