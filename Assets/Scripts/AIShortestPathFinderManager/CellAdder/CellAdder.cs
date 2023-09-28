using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.CellAdder
{
    public class CellAdder : MonoBehaviour, ICellAdder
    {
        public void AddCellToPath(ref List<KeyValuePair<IGridCell, Vector3>> path, ref IGridCell pathCell, IGridCell currentCell, Material material)
        {
            path.Add(KeyValuePair.Create(currentCell, Vector3.Normalize(pathCell.GetGameObject().transform.position - currentCell.GetGameObject().transform.position)));
            pathCell.GetGameObject().GetComponent<MeshRenderer>().enabled = true;
            pathCell.GetGameObject().GetComponent<MeshRenderer>().material = material;
        }
        public void AddCellToPath(ref List<KeyValuePair<IGridCell, Vector3>> path, IGridCell pathCell)
        {
                path.Add(KeyValuePair.Create(pathCell, new Vector3(0, 0, 0)));
        }
    }
}