using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GridCellManager
{
    public interface ICollisionHandler
    {
        void HandleTriggers(Collider other);
    }
}