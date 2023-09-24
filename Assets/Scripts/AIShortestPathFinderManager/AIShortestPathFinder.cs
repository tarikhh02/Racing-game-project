using Assets.Scripts.GridCellManager;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.MovementManager;
using Race_game_project.StartCellFinder;
using Race_game_project.WalkableCellsFinderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Race_game_project.AIPathFinderManager
{
    public class AIShortestPathFinder : MonoBehaviour, IAIShortestPathFinder
    {
        [SerializeField]
        GameObject _firstHalfGrid;
        [SerializeField]
        GameObject _secondHalfGrid;
        IGridCell _startCell;
        IObjectMover _objectMoverComponent;
        IStartCellFinder _startCellFinder;
        IWalklableCellsFinder _walkableCellsFinder;
        List<IGridCell> path = new List<IGridCell>();
        void Awake()
        {
            _startCellFinder = this.gameObject.GetComponent<StartCellFinder.StartCellFinder>();
            _walkableCellsFinder = this.gameObject.GetComponent<WalkableCellsFinder>();
            //_objectMoverComponent = this.gameObject.GetComponent<ObjectMover>();
            _startCellFinder.GetStartCell(ref _startCell);
            FindShortestPath(_firstHalfGrid, _startCell, 0f);
        }
        private void FindShortestPath(GameObject gridComponent, IGridCell currentCell, float previousDistance)
        {
            List<IGridCell> cellsToChooseFrom = new List<IGridCell>();
            int x = currentCell.GetX();
            int y = currentCell.GetY();
            float scale = currentCell.GetGameObject().transform.localScale.x;
            float currentDistance = previousDistance + scale + Math.Abs(currentCell.GetDirection().x * currentCell.GetDirection().z);
            cellsToChooseFrom = _walkableCellsFinder.FindWalkableCells(gridComponent.GetComponentInChildren<GridInitialization>().GetGridHeight(), 
               gridComponent.GetComponentInChildren<GridInitialization>().GetGridWidth(), gridComponent.transform.position, cellsToChooseFrom, x, y, scale);
        }
    } 
}
