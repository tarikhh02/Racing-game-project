﻿using Assets.Scripts.GridCellManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.StartCellFinder
{
    public class StartCellFinder : MonoBehaviour, IStartCellFinder
    {
        public void GetStartCell(ref IGridCell startCell)
        {
            RaycastHit hit;
            Debug.DrawRay(this.transform.position + this.transform.forward * this.transform.localScale.z / 2, -this.transform.up * 2f, Color.red, 100f);
            if (Physics.Raycast(this.transform.position + this.transform.forward * this.transform.localScale.z / 2, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.gameObject.tag == "GridCell")
                {
                    startCell = hit.collider.gameObject.GetComponent<GridCell>();
                }
            }
        }
    }
}