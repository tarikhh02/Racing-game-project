using Assets.Scripts.GridCellManager;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace Race_game_project.CellAdder
{
    public class CellAdder : MonoBehaviour, ICellAdder
    {
        public void AddCellToPath(ref List<KeyValuePair<IGridCell, UnityEngine.Vector3>> path, ref IGridCell pathCell, IGridCell currentCell, Material material)
        {
            path.Add(KeyValuePair.Create(currentCell, UnityEngine.Vector3.Normalize(pathCell.GetGameObject().transform.position - this.transform.position)));
            pathCell.GetGameObject().GetComponent<MeshRenderer>().enabled = true;
            pathCell.GetGameObject().GetComponent<MeshRenderer>().material = material;
        }
    }
}