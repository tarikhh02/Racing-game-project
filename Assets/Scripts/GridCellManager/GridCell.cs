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
        public int _x;
        public int _y;
        public int _cost;
        Vector3 _direction;
        public void SetUpCell(Transform parent, int y, int x)
        {
            _x = x;
            _y = y;
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
        public Vector3 GetDirection()
        {
            return _direction;
        }
        public void SetCost(int cost)
        {
            _cost = cost;
        }
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}