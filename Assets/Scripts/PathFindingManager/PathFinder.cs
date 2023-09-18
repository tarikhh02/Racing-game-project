using Assets.Scripts.GridInitializer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GridCellManager;
using Racing_game_project.CellMarkerManager;
using Race_game_project.CellUnwalkableMaker;

namespace Assets.Scripts.PathFindingManager
{
    [ExecuteInEditMode]
    public class PathFinder : MonoBehaviour, IPathFinder
    {
        IGridInitialization _gridInitComponent;
        ISetCostFromEndToRest _costSetterComponent;
        ICellDirectionSetter _cellDirectionSettingComponent;
        ICellUnwalkableMarker _cellMarkerComponent;
        Tuple<int, int> _startIndex = null;
        Tuple<int, int> _endIndex = null;
        private void OnEnable()
        {
            _gridInitComponent = this.GetComponent<GridInitialization>();
            _costSetterComponent = this.GetComponent<SetCostFromEndToRest>();
            _cellDirectionSettingComponent = this.GetComponent<CellDirectionSetter>();
            _cellMarkerComponent = this.GetComponent<CellUnwalkableMarker>();
            FindPath();
            this.enabled = false;
        }
        public void FindPath()
        {
            _gridInitComponent.SetUpGrid();
            _cellMarkerComponent.MarkCellAsUnwalkabe();
            _costSetterComponent.SetCostFromEnd(ref _gridInitComponent.GetGrid(), _endIndex.Item1, _endIndex.Item2, 0);
            //Direction setting finished, rays are not drawing properly, has to be fixed
            _cellDirectionSettingComponent.SetEachCellDirection(ref _gridInitComponent.GetGrid());
        }
        public Tuple<int, int> GetStartIndex()
        {
            return _startIndex;
        }
        public Tuple<int, int> GetEndIndex()
        {
            return _endIndex;
        }
        public void SetStartIndex(int x, int y)
        {
            _startIndex = Tuple.Create(x, y);
        }
        public void SetEndIndex(int x, int y)
        {
            _endIndex = Tuple.Create(x, y); 
        }
    }
}