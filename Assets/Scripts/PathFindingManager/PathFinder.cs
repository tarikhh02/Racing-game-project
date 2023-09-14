using Assets.Scripts.GridInitializer;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PathFindingManager
{
    public class PathFinder : MonoBehaviour, IPathFinder
    {
        IGridInitialization _gridInitComponent;
        ICellCostSetter _cellCostSetter;
        Tuple<int, int> _startIndex;
        Tuple<int, int> _endIndex;
        private void Start()
        {
            _cellCostSetter = GetComponent<CellCostSetter>();
            _gridInitComponent = GetComponent<GridInitialization>();
            Invoke("FindPath",1f);
        }
        public void FindPath()
        {
            _cellCostSetter.SetCellCosts();
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