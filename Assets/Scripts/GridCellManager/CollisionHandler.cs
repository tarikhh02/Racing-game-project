using Assets.Scripts.GridInitializer;
using Assets.Scripts.GridCellManager;
using System;
using System.Collections;
using UnityEngine;
using Assets.Scripts.PathFindingManager;

namespace Assets.Scripts.GridCellManager
{
    public class CollisionHandler : MonoBehaviour
    {
        IPathFinder _pathFindingComponent;
        IGridCell _cell;
        private void Awake()
        {
            _cell = this.GetComponent<GridCell>();
        }
        private void OnTriggerEnter(Collider other)
        {
            HandleTriggers(other);
        }

        private void HandleTriggers(Collider other)
        {
            if (other.gameObject.tag == "Start")
            {
                _pathFindingComponent = this.GetComponentInParent<PathFinder>();
                if (_pathFindingComponent.GetStartIndex() == null)
                {
                    _pathFindingComponent.SetStartIndex(_cell.GetX(), _cell.GetY());
                }
            }
            else if (other.gameObject.tag == "End")
            {
                _pathFindingComponent = this.GetComponentInParent<PathFinder>();
                if (_pathFindingComponent.GetEndIndex() == null)
                {
                    _pathFindingComponent.SetEndIndex(_cell.GetX(), _cell.GetY());
                }
            }
        }
    }
}