using Assets.Scripts.GridInitializer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GridCellManager;

namespace Assets.Scripts.PathFindingManager
{
    public class PathFinder : MonoBehaviour, IPathFinder
    {
        IGridInitialization _gridInitComponent;
        ISetCostFromEndToRest _costSetterComponent;
        ICellDirectionSetter _cellDirectionSettingComponent;
        Tuple<int, int> _startIndex;
        Tuple<int, int> _endIndex;
        private void Awake()
        {
            _costSetterComponent = this.GetComponent<SetCostFromEndToRest>();
            _gridInitComponent = this.GetComponent<GridInitialization>();
            _cellDirectionSettingComponent = this.GetComponent<CellDirectionSetter>();
            Invoke("FindPath",1f);
        }
        public void FindPath()
        {
            ref List<List<IGridCell>> grid = ref _gridInitComponent.GetGrid();
            _costSetterComponent.SetCostFromEnd(ref grid, _endIndex.Item1, _endIndex.Item2, 1);
            //Direction setting finished, rays are not drawing properly, has to be fixed
            _cellDirectionSettingComponent.SetEachCellDirection(ref grid);
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