using Assets.Scripts.GridInitializer;
using Assets.Scripts.GridCellManager;
using System;
using System.Collections;
using UnityEngine;
using Assets.Scripts.PathFindingManager;

namespace Assets.Scripts.GridCellManager
{
    [ExecuteInEditMode]
    public class CollisionHandler : MonoBehaviour, ICollisionHandler
    {
        IPathFinder _pathFindingComponent;
        public void HandleTriggers(GameObject startPoint, GameObject endPoint)
        {
            _pathFindingComponent = this.GetComponentInParent<PathFinder>();
            Collider[] startColliders = Physics.OverlapBox(startPoint.transform.position, startPoint.transform.localScale / (2 * 10), Quaternion.identity);
            Collider[] endColliders = Physics.OverlapBox(endPoint.transform.position, endPoint.transform.localScale / (2 * 10), Quaternion.identity);
            foreach (var c in startColliders)
            {
                if (c.tag == "GridCell")
                {
                    _pathFindingComponent.SetStartIndex(c.gameObject.GetComponent<GridCell>().GetX(), c.gameObject.GetComponent<GridCell>().GetY());
                }
            }
            foreach (var c in endColliders)
            {
                if (c.tag == "GridCell")
                {
                    _pathFindingComponent.SetEndIndex(c.gameObject.GetComponent<GridCell>().GetX(), c.gameObject.GetComponent<GridCell>().GetY());
                }
            }
        }
    }
}