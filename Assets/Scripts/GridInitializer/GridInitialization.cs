using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GridCellManager;
using Assets.Scripts.PathFindingManager;

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
        [SerializeField]
        GameObject startPoint;
        List<List<IGridCell>> _grid = new List<List<IGridCell>>();
        ICollisionHandler _collisionHandler;
        public void SetUpGrid()
        {
            _collisionHandler = this.GetComponent<CollisionHandler>();
            for (int i = 0; i < _gridHeight; i++)
            {
                _grid.Add(new List<IGridCell>());
                for (int j = 0; j < _gridWidth; j++)
                {
                    cellPrefab.transform.position = new Vector3(this.transform.position.x + cellPrefab.transform.localScale.x / 2 + j * cellPrefab.transform.localScale.x, 
                                                                0.01f, transform.position.z + cellPrefab.transform.localScale.z / 2 + i * cellPrefab.transform.localScale.z);
                    IGridCell cellObj = Instantiate(cellPrefab).GetComponent<GridCell>();
                    _grid[i].Add(cellObj);
                    cellObj.SetUpCell(this.transform, i, j);
                }
            }
            _collisionHandler.HandleTriggers(startPoint, endPoint);
        }
        public ref List<List<IGridCell>> GetGrid()
        {
            return ref _grid;
        }
        public GameObject GetStartPoint()
        {
            return startPoint;
        }
        public GameObject GetEndPoint()
        {
            return endPoint;
        }
    }
}
