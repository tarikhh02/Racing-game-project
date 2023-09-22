using Assets.Scripts.GridCellManager;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.MovementManager;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Race_game_project.AIPathFinderManager
{
    public class AIShortestPathFinder : MonoBehaviour, IAIShortestPathFinder
    {
        [SerializeField]
        GameObject _firstHalfGrid;
        [SerializeField]
        GameObject _secondHalfGrid;
        IGridCell _startCell;
        IObjectMover _objectMoverComponent;
        List<IGridCell> path;
        void Awake()
        {
            GetStartCell();
            FindShortestPath(_firstHalfGrid.GetComponentInChildren<GridInitialization>().GetGridHeight(), _firstHalfGrid.GetComponentInChildren<GridInitialization>().GetGridWidth(), _startCell, 0f);
        }
        private void GetStartCell()
        {
            RaycastHit hit;
            Debug.DrawRay(this.transform.position + this.transform.forward * this.transform.localScale.z / 2, -this.transform.up * 2f, Color.red, 100f);
            if(Physics.Raycast(this.transform.position + this.transform.forward * this.transform.localScale.z / 2, -this.transform.up, out hit, 0.5f))
            {
                if(hit.collider.gameObject.tag == "GridCell")
                {
                    _startCell =  hit.collider.gameObject.GetComponent<GridCell>();
                }
            }
        }
        private void FindShortestPath(int height, int width, IGridCell currentCell, float previousDistance)
        {
            List<IGridCell> cellsToChooseFrom = new List<IGridCell>();
            int x = currentCell.GetX();
            int y = currentCell.GetY();
            float scale = currentCell.GetGameObject().transform.localScale.x;
            if(x < width - 1)
            {
                cellsToChooseFrom.Add(FindCell(_firstHalfGrid.transform.position, x + 1, y, scale));
                CheckYAxis(height, ref cellsToChooseFrom, x + 1, y, scale);
            }
            if (x > 0)
            {
                cellsToChooseFrom.Add(FindCell(_firstHalfGrid.transform.position, x - 1, y, scale));
                CheckYAxis(height, ref cellsToChooseFrom, x - 1, y, scale);
            }
            CheckYAxis(height, ref cellsToChooseFrom, x, y, scale);
            SortCellsByCost(ref cellsToChooseFrom);
        }

        private void SortCellsByCost(ref List<IGridCell> cellsToChoseFrom)
        {
            IGridCell minCostCell = null;
            foreach(IGridCell cell in cellsToChoseFrom)
            {
                if (minCostCell == null)
                    minCostCell = cell;
                else if (minCostCell.GetCost() > cell.GetCost())
                    minCostCell = cell;
            }
        }

        private void CheckYAxis(int height, ref List<IGridCell> cellsToChooseFrom, int x, int y, float scale)
        {
            if (y < height - 1)
            {
                cellsToChooseFrom.Add(FindCell(_firstHalfGrid.transform.position, x, y + 1, scale));
            }
            if (y > 0)
            {
                cellsToChooseFrom.Add(FindCell(_firstHalfGrid.transform.position, x, y - 1, scale));
            }
        }
        private GridCell FindCell(Vector3 gridStart, int x, int y, float scale)
        {
            Vector3 rayPosition = new Vector3
            {
                x = scale / 2 + scale * x + gridStart.x,
                y = gridStart.y,
                z = scale / 2 + scale * y + gridStart.z,
            };
            Debug.DrawRay(rayPosition, -transform.up * 0.5f, Color.red, 20f);
            Collider[] colliders = Physics.OverlapBox(rayPosition, new Vector3(0.001f, 0.5f, 0.001f));
            foreach(Collider collider in colliders)
            {
                if (collider.gameObject.tag == "GridCell")
                {
                    return collider.gameObject.GetComponent<GridCell>();
                }
            }
            return null;
        }
    } 
}
