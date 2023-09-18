using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GridCellManager
{
    public interface ICollisionHandler
    {
        public void HandleTriggers(GameObject startPoint, GameObject endPoint);
    }
}