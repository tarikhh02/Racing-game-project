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
        public void HandleTriggersForStartAndEnd(GameObject endPoint)
        {
            _pathFindingComponent = this.gameObject.GetComponent<PathFinder>();
            Collider[] endColliders = Physics.OverlapBox(endPoint.transform.position, new Vector3(0.001f, 0.3f, 0.001f));
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