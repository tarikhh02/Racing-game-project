using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Scripts.GridInitializer;

namespace Assets.Scripts.GridCellManager
{
    public class GridCell : MonoBehaviour, IGridCell
    {
        int _x;
        int _y;
        int _cost;
        Quaternion _rotationDirection;
        public void SetUpCell(Transform parent, int i, int j)
        {
            _x = j;
            _y = i;
            this.transform.SetParent(parent);
        }
        public int GetX()
        {
            return _x;
        }
        public int GetY()
        {
            return _y;
        }
        public int GetCost()
        {
            return _cost;
        }
        public Quaternion GetRotationDirection()
        {
            return _rotationDirection;
        }
        public void SetCost(int cost)
        {
            _cost = cost;
        }
        public void SetRotationDirection(Quaternion rotationDirection)
        {
            _rotationDirection = rotationDirection;
        }
    }
}