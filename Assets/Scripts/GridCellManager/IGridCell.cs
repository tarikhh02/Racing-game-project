using System.Collections;
using UnityEngine;
using static UnityEngine.GridBrushBase;

namespace Assets.Scripts.GridCellManager
{
    public interface IGridCell
    {
        public void SetUpCell(Transform parent, int i, int j);
        public int GetX();
        public int GetY();
        public int GetCost();
        public Quaternion GetRotationDirection();
        public void SetCost(int cost);
        public void SetRotationDirection(Quaternion rotationDirection);

    }
}