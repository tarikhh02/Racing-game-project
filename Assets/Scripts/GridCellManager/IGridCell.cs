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
        public bool GetChecked();
        public Vector3 GetDirection();
        public void SetCost(int cost);
        public int GetCost();
        public void SetCostIncrementValue(int costIncrementValue);
        public void SetDirection(Vector3 direction);
        public GameObject GetGameObject();

    }
}