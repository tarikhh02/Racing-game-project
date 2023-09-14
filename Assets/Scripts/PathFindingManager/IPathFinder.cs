using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PathFindingManager
{
    public interface IPathFinder
    {
        public Tuple<int, int> GetStartIndex();
        public Tuple<int, int> GetEndIndex();
        public void SetStartIndex(int x, int y);
        public void SetEndIndex(int x, int y);
    }
}