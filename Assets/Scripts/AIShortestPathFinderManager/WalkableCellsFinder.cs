using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.WalkableCellsFinderManager
{
    public class WalkableCellsFinder : MonoBehaviour, IWalklableCellsFinder
    {
        public List<IGridCell> FindWalkableCells(int height, int width, Vector3 gridPosition, List<IGridCell> cellsToChooseFrom, int x, int y, float scale)
        {
            if (x < width - 1)
            {
                var cell = CheckCell(gridPosition, x + 1, y, scale);
                CheckYAxis(height, gridPosition, ref cellsToChooseFrom, x + 1, y, scale);
                AddCellToList(ref cellsToChooseFrom, ref cell);
            }
            if (x > 0)
            {
                var cell = CheckCell(gridPosition, x - 1, y, scale);
                CheckYAxis(height, gridPosition, ref cellsToChooseFrom, x - 1, y, scale);
                AddCellToList(ref cellsToChooseFrom, ref cell);
            }
            CheckYAxis(height, gridPosition, ref cellsToChooseFrom, x, y, scale);
            return cellsToChooseFrom;
        }
        private void CheckYAxis(int height, Vector3 gridPosition, ref List<IGridCell> cellsToChooseFrom, int x, int y, float scale)
        {
            if (y < height - 1)
            {
                var cell = CheckCell(gridPosition, x, y + 1, scale);
                AddCellToList(ref cellsToChooseFrom, ref cell);
            }
            if (y > 0)
            {
                var cell = CheckCell(gridPosition, x, y - 1, scale);
                AddCellToList(ref cellsToChooseFrom, ref cell);
            }
        }
        private void AddCellToList(ref List<IGridCell> cellsToChooseFrom, ref GridCell cell)
        {
            Debug.DrawRay(cell.transform.position, -transform.up * 0.5f, Color.red, 20f);
            if (cell != null)
                cellsToChooseFrom.Add(cell);
        }
        private GridCell CheckCell(Vector3 gridStart, int x, int y, float scale)
        {
            Vector3 centerPos = new Vector3
            {
                x = scale / 2 + scale * x + gridStart.x,
                y = gridStart.y,
                z = scale / 2 + scale * y + gridStart.z,
            };
            Collider[] colliders = Physics.OverlapBox(centerPos, new Vector3(0.001f, 0.5f, 0.001f));
            foreach (Collider collider in colliders)
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