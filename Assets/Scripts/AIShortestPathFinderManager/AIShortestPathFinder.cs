using Assets.Scripts.GridCellManager;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.MovementManager;
using Race_game_project.CellAdder;
using Race_game_project.CellForPathChooserComponent;
using Race_game_project.ListSortingManager;
using Race_game_project.PathCleaningManager;
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
        IPathClearingManager _pathClearingComponent;
        List<KeyValuePair<IGridCell, Vector3>> _path = new List<KeyValuePair<IGridCell, Vector3>>();
        Guid _id;
        private void SetUpBeginningOfPathFinding(bool isStart)
        {
            if (!isStart)
                return;
            _startCellFinder = this.gameObject.GetComponent<StartCellFinder.StartCellFinder>();
            _walkableCellsFinder = this.gameObject.GetComponent<WalkableCellsFinder>();
            _objectMoverComponent = this.gameObject.GetComponent<ObjectMover>();
            _cellListSorter = this.gameObject.GetComponent<ListByCostSorter>();
            _cellFinderComponent = this.gameObject.GetComponent<CellForPathChooser>();
            _cellAddComponent = this.gameObject.GetComponent<CellAdder.CellAdder>();
            _pathFinishedChecker = this.gameObject.GetComponent<IsPathFinishedChecker>();
            _pathClearingComponent = this.gameObject.GetComponent<PathClearingManager>();
            _startCell = _startCellFinder.GetStartCell();
            if (_startCell != null)
            {
                _startCell.AddCarThatVillPass(this, 0f, 0f);
                _pathClearingComponent.ClearPath(ref _path);
                _startCell.GetGameObject().GetComponent<MeshRenderer>().enabled = true;
                _startCell.GetGameObject().GetComponent<MeshRenderer>().material = pathMaterial;
            }
        }
        public void FindShortestPath(GameObject gridComponent, float previousDistance, bool isStart = false)
        {
            SetUpBeginningOfPathFinding(isStart);
            if (_startCell == null)
                return;

            var currentCell = _startCell;
            List<IGridCell> cellsToChooseFrom = new List<IGridCell>();
            int x = currentCell.GetX();
            int y = currentCell.GetY();
            float scale = currentCell.GetGameObject().transform.localScale.x;
            cellsToChooseFrom = _walkableCellsFinder.FindWalkableCells(gridComponent.GetComponentInChildren<GridInitialization>().GetGridHeight(), 
               gridComponent.GetComponentInChildren<GridInitialization>().GetGridWidth(), gridComponent.transform.position, cellsToChooseFrom, x, y, scale);
            _cellListSorter.SortList(ref cellsToChooseFrom);
            ref IGridCell pathCell = ref _cellFinderComponent.ChooseCellForPath(ref cellsToChooseFrom, ref previousDistance, scale, _objectMoverComponent.GetSpeed());
            if (pathCell == null)
                return;
            _cellAddComponent.AddCellToPath(ref _path, ref pathCell, currentCell, pathMaterial);
            if (!_pathFinishedChecker.IsPathFinished(pathCell, gridComponent.GetComponentInChildren<GridInitialization>().GetEndPoint().transform.position, _path.Count))
            {
                _startCell = pathCell;
                FindShortestPath(gridComponent, previousDistance);
            }
            else
            {
                _cellAddComponent.AddCellToPath(ref _path, pathCell);
            }
        }
        public List<KeyValuePair<IGridCell, Vector3>> GetPath()
        {
            return _path;
        }
        public Guid GetId()
        {
            return _id;
        }
        public void SetId(Guid id)
        {
            _id = id;
        }
    } 
}
