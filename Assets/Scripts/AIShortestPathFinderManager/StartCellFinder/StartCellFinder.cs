using Assets.Scripts.GridCellManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.StartCellFinder
{
    public class StartCellFinder : MonoBehaviour, IStartCellFinder
    {
        public IGridCell GetStartCell()
        {
            RaycastHit hit;
            Vector3 forwardVec = this.transform.position + Vector3.up * 0.2f + this.transform.forward * this.transform.localScale.z / 2;
            if (Physics.Raycast(forwardVec, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.gameObject.tag == "GridCell")
                {
                    return hit.collider.gameObject.GetComponent<GridCell>();
                }
            }
            return null;
        }
    }
}