using Assets.Scripts.GridCellManager;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.MovementManager;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.AIPathFinderManager
{
    public class AIShortestPathFinder : MonoBehaviour, IAIShortestPathFinder
    {
        [SerializeField]
        GridInitialization _firstHalfGrid;
        [SerializeField]
        GridInitialization _secondHalfGrid;
        IGridCell startCell;
        List<IGridCell> path;
        void Awake()
        {
            FindShortestPath();
        }
        private void GetCurrentCell()
        {
            RaycastHit hit;
            Debug.DrawRay(this.transform.position + this.transform.forward * this.transform.localScale.z / 2, -this.transform.up * 2f, Color.red, 100f);
            if(Physics.Raycast(this.transform.position + this.transform.forward * this.transform.localScale.z / 2, -this.transform.up, out hit, 0.5f))
            {
                if(hit.collider.gameObject.tag == "GridCell")
                {
                    startCell =  hit.collider.gameObject.GetComponent<GridCell>();
                }
            }
        }
        private void FindShortestPath()
        {
            GetCurrentCell();
            int x = startCell.GetX();
            int y = startCell.GetY();
            Vector3 currentDirection = startCell.GetDirection();
            

        }
    } 
}
