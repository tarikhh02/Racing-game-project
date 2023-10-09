using Assets.Scripts.GridCellManager;
using Race_game_project.AIPathFinderManager;
using Race_game_project.IdHandlingManager;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.VisibleCellFinder
{
    public class VisibleCellFinderManager : MonoBehaviour, IVIsibleCellFinderManager
    {
        IAIShortestPathFinder _aiPathFinder;
        private void Awake()
        {
            _aiPathFinder = this.gameObject.GetComponent<AIShortestPathFinder>();
        }
        public void FindCells(List<IGridCell> listOfVisibleToCell, ref Vector3 _direction, ref bool hasFoundCell)
        {
            foreach (var cell in listOfVisibleToCell)
            {
                if (cell == null)
                    continue;
                foreach (var car in cell.GetListOfCarsThatWillPass())
                {
                    if (this.GetComponent<IdHandler>().GetId() == car.Key.GetId())
                    {
                        var path = _aiPathFinder.GetPath();
                        foreach (var pathCell in path)
                        {
                            if (pathCell.Key.GetX() == cell.GetX() && pathCell.Key.GetY() == cell.GetY())
                            {
                                _direction = pathCell.Value;
                                hasFoundCell = true;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (hasFoundCell)
                    break;
            }
        }
    }
}