using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.PathFindingManager
{
    [ExecuteInEditMode]
    public class CellDirectionSetter : MonoBehaviour, ICellDirectionSetter
    {
        List<IGridCell> _costsToChoose = new List<IGridCell>();
        public void SetEachCellDirection(ref List<List<IGridCell>> gridWithCellCostsSet)
        {
            for (int y = 0; y < gridWithCellCostsSet.Count; y++) 
            {
                for (int x = 0; x < gridWithCellCostsSet[y].Count; x++)
                {
                    _costsToChoose.Clear();
                    CheckXAxis(ref gridWithCellCostsSet, x, y);
                    CheckYAxis(ref gridWithCellCostsSet, x, y);
                    IGridCell cellWithMinCost = _costsToChoose.Find(s => s.GetCost() == _costsToChoose.Min(s => s.GetCost()));
                    Vector3 dir = cellWithMinCost.GetGameObject().transform.position - gridWithCellCostsSet[y][x].GetGameObject().transform.position;
                    gridWithCellCostsSet[y][x].SetDirection(Vector3.Normalize(dir));
                    Debug.DrawRay(new Vector3() { 
                        x = this.transform.position.x + gridWithCellCostsSet[y][x].GetGameObject().transform.localScale.x / 2 + gridWithCellCostsSet[y][x].GetGameObject().transform.localScale.x * x,
                        y = this.transform.position.y,
                        z = this.transform.position.z + gridWithCellCostsSet[y][x].GetGameObject().transform.localScale.x / 2 + gridWithCellCostsSet[y][x].GetGameObject().transform.localScale.z * y
                    }, gridWithCellCostsSet[y][x].GetDirection() * gridWithCellCostsSet[y][x].GetGameObject().transform.localScale.x, Color.blue, 60f);
                }
            }
        }
        void CheckYAxis(ref List<List<IGridCell>> gridWithCellCostsSet, int x, int y)
        {
            if (y < gridWithCellCostsSet.Count - 1)
            {
                _costsToChoose.Add(gridWithCellCostsSet[y + 1][x]);
            }
            if (y > 0)
            {
                _costsToChoose.Add(gridWithCellCostsSet[y - 1][x]);
            }
        }
        void CheckXAxis(ref List<List<IGridCell>> gridWithCellCostsSet, int x, int y)
        {
            if (x < gridWithCellCostsSet[y].Count - 1)
            {
                CheckYAxis(ref gridWithCellCostsSet, x + 1, y);
                _costsToChoose.Add(gridWithCellCostsSet[y][x + 1]);
            }
            if (x > 0)
            {
                CheckYAxis(ref gridWithCellCostsSet, x - 1, y);
                _costsToChoose.Add(gridWithCellCostsSet[y][x - 1]);
            }
        }
    }
}