using Assets.Scripts.GridCellManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GridInitializer
{
    public interface IGridInitialization
    {
        void SetUpGrid();
        public ref List<List<IGridCell>> GetGrid();
        public GameObject GetEndPoint();
        public int GetGridWidth();
        public int GetGridHeight();
    }
}