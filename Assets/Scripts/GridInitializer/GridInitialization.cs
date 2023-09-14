using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GridCellManager;

namespace Assets.Scripts.GridInitializer { 
    public class GridInitialization : MonoBehaviour, IGridInitialization
    {
        [SerializeField]
        GameObject cellPrefab;
        [SerializeField]
        int _gridWidth;
        [SerializeField]
        int _gridHeight;
        List<List<IGridCell>> _grid = new List<List<IGridCell>>();

        private void Awake()
        {
            SetUpGrid();
        }

        public void SetUpGrid()
        {
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
        }
        public ref List<List<IGridCell>> GetGrid()
        {
            return ref _grid;
        }
    }
}
