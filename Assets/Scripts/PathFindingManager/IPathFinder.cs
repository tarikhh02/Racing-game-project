using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PathFindingManager
{
    public interface IPathFinder
    {
        public Tuple<int, int> GetEndIndex();
        public void SetEndIndex(int x, int y);
    }
}