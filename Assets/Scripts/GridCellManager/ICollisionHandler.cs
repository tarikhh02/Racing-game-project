using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GridCellManager
{
    public interface ICollisionHandler
    {
        public void HandleTriggersForStartAndEnd(GameObject startPoint, GameObject endPoint);
    }
}