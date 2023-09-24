using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GridCellManager;
using Assets.Scripts.PathFindingManager;
using UnityEngine.UIElements;

namespace Assets.Scripts.GridInitializer {

    [ExecuteInEditMode]
    public class GridInitialization : MonoBehaviour, IGridInitialization
    {
        [SerializeField]
        GameObject cellPrefab;
        [SerializeField]
        int _gridWidth;
        [SerializeField]
        int _gridHeight;
        [SerializeField]
        GameObject endPoint;
        List<List<IGridCell>> _grid = new List<List<IGridCell>>();
        ICollisionHandler _collisionHandler;
        public void SetUpGrid()
        {
            _grid.Clear();
            _collisionHandler = this.GetComponent<CollisionHandler>();
            for (int i = 0; i < _gridHeight; i++)
            {
                _grid.Add(new List<IGridCell>());
                for (int j = 0; j < _gridWidth; j++)
                {
                    cellPrefab.transform.position = new Vector3(this.transform.position.x + cellPrefab.transform.localScale.x / 2 + j * cellPrefab.transform.localScale.x, 
                                                                0.1f, transform.position.z + cellPrefab.transform.localScale.z / 2 + i * cellPrefab.transform.localScale.z);
                    cellPrefab.transform.position = cellPrefab.transform.localPosition;
                     IGridCell cellObj = Instantiate(cellPrefab).GetComponent<GridCell>();
                    _grid[i].Add(cellObj);
                    cellObj.SetUpCell(this.transform.parent, i, j);
                }
            }
            _collisionHandler.HandleTriggersForStartAndEnd(endPoint);
        }
        public ref List<List<IGridCell>> GetGrid()
        {
            return ref _grid;
        }
        public GameObject GetEndPoint()
        {
            return endPoint;
        }
        public int GetGridWidth()
        {
            return _gridWidth;
        }
        public int GetGridHeight()
        {
            return _gridHeight;
        }
    }
}
