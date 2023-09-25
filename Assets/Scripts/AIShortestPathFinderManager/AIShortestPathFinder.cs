using Assets.Scripts.GridCellManager;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.MovementManager;
using Race_game_project.CellAdder;
using Race_game_project.CellForPathChooserComponent;
using Race_game_project.ListSortingManager;
using Race_game_project.PathFinishChecker;
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
        Material pathMaterial;
        IGridCell _startCell;
        IObjectMover _objectMoverComponent;
        IStartCellFinder _startCellFinder;
        IWalklableCellsFinder _walkableCellsFinder;
        IListByCostSorter _cellListSorter;
        ICellForPathChooser _cellFinderComponent;
        ICellAdder _cellAddComponent;
        IIsPathFinishedChecker _pathFinishedChecker;
        List<KeyValuePair<IGridCell, Vector3>> path = new List<KeyValuePair<IGridCell, Vector3>>();
        int _id = 0;
        public static int lastId = 0;
        private bool _isStart = true;
        private void GetComponents()
        {
            if (!_isStart)
                return;
            _id = lastId++;
            _startCellFinder = this.gameObject.GetComponent<StartCellFinder.StartCellFinder>();
            _walkableCellsFinder = this.gameObject.GetComponent<WalkableCellsFinder>();
            _objectMoverComponent = this.gameObject.GetComponent<ObjectMover>();
            _cellListSorter = this.gameObject.GetComponent<ListByCostSorter>();
            _cellFinderComponent = this.gameObject.GetComponent<CellForPathChooser>();
            _cellAddComponent = this.gameObject.GetComponent<CellAdder.CellAdder>();
            _pathFinishedChecker = this.gameObject.GetComponent<IsPathFinishedChecker>();
            _startCell = _startCellFinder.GetStartCell();
            //FindShortestPath(_firstHalfGrid, 0f);
            _isStart = false;
        }
        public void FindShortestPath(GameObject gridComponent, float previousDistance)
        {
            GetComponents();
            var currentCell = _startCell;
            List<IGridCell> cellsToChooseFrom = new List<IGridCell>();
            int x = currentCell.GetX();
            int y = currentCell.GetY();
            float scale = currentCell.GetGameObject().transform.localScale.x;
            cellsToChooseFrom = _walkableCellsFinder.FindWalkableCells(gridComponent.GetComponentInChildren<GridInitialization>().GetGridHeight(), 
               gridComponent.GetComponentInChildren<GridInitialization>().GetGridWidth(), gridComponent.transform.position, cellsToChooseFrom, x, y, scale);
            _cellListSorter.SortList(ref cellsToChooseFrom);
            IGridCell pathCell = _cellFinderComponent.ChooseCellForPath(ref cellsToChooseFrom, ref previousDistance, scale, _objectMoverComponent.GetSpeed());
            _cellAddComponent.AddCellToPath(ref path, ref pathCell, currentCell, pathMaterial);
            if (!_pathFinishedChecker.IsPathFinished(pathCell, gridComponent.GetComponentInChildren<GridInitialization>().GetEndPoint().transform.position))
            {
                _startCell = pathCell;
                FindShortestPath(gridComponent, previousDistance);
            }
        }
        public int GetId()
        { 
            return _id; 
        }
    } 
}
