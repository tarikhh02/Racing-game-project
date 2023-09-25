using Assets.Scripts.GridCellManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.PathFinishChecker
{
    public interface IIsPathFinishedChecker
    {
        public bool IsPathFinished(IGridCell pathCell, Vector3 endPosition);
    }
}