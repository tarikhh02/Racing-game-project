using Assets.Scripts.GridInitializer;
using System;
using UnityEngine;
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
            _cellMarkerComponent.MarkCellAsUnwalkabe(ref _gridInitComponent.GetGrid());
            _costSetterComponent.SetCostFromEnd(ref _gridInitComponent.GetGrid(), _endIndex.Item1, _endIndex.Item2, 0);
            _cellDirectionSettingComponent.SetEachCellDirection(ref _gridInitComponent.GetGrid(), _gridInitComponent.GetEndPoint());
        }
        public Tuple<int, int> GetEndIndex()
        {
            return _endIndex;
        }
        public void SetEndIndex(int x, int y)
        {
            _endIndex = Tuple.Create(x, y); 
        }
    }
}