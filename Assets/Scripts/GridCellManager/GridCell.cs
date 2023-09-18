using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.PathFindingManager;
using System.Data;

namespace Assets.Scripts.GridCellManager
{
    [ExecuteInEditMode]
    public class GridCell : MonoBehaviour, IGridCell
    {
        [SerializeField]
        Material checkedCol;
        public int _x;
        public int _y;
        public int _cost;
        int _costIncrementValue = 1;
        public Vector3 _direction;
        bool _isChecked = false;
        public void SetUpCell(Transform parent, int y, int x)
        {
            this.gameObject.tag = "GridCell";
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
        public bool GetChecked()
        {
            return _isChecked;
        }
        public Vector3 GetDirection()
        {
            return _direction;
        }
        public void SetCost(int cost)
        {
            _isChecked = true;
            _cost = cost + _costIncrementValue;
        }
        public int GetCost()
        {
            return _cost;
        }
        public void SetCostIncrementValue(int costIncrementValue)
        {
            _costIncrementValue = costIncrementValue;
        }
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
        public GameObject GetGameObject()
        {
            return this.gameObject;
        }
    }
}