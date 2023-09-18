using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Scripts.GridCellManager;
using Race_game_project.CellUnwalkableMaker;

namespace Racing_game_project.CellMarkerManager
{
    [ExecuteInEditMode]
    public class CellUnwalkableMarker : MonoBehaviour, ICellUnwalkableMarker
    {
        [SerializeField]
        GameObject[] obsticles;
        public void MarkCellAsUnwalkabe()
        {
            foreach (var obsticle in obsticles)
            {
                Collider[] colliders = Physics.OverlapBox(obsticle.transform.position, obsticle.transform.localScale / 2, obsticle.transform.rotation);
                foreach (var collider in colliders)
                {
                    if (collider.gameObject.tag == "GridCell")
                    {
                        IGridCell currentCell = collider.gameObject.GetComponent<GridCell>();
                        if (!currentCell.GetChecked())
                        {
                            currentCell.SetCost(60000);
                        }
                    }
                }
            }
        }
    }
}