using Assets.Scripts.GridInitializer;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PathFindingManager
{
    public class PathFinder : MonoBehaviour, IPathFinder
    {
        GridInitialization _gridInitComponent;
        Tuple<int, int> _startIndex;
        Tuple<int, int> _endIndex;
        private void Awake()
        {
            
        }
        public void FindPath()
        {

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