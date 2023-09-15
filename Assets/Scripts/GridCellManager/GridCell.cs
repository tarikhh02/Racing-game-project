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
    public class GridCell : MonoBehaviour, IGridCell
    {
        [SerializeField]
        Material checkedCol;
        public int _x;
        public int _y;
        public int _cost;
        public Vector3 _direction;
        bool _isChecked = false;
        public static float intcrementVal=0;///////////////////////////////////////////////////////////////////
        public void SetCol()/////////////////////////////////////////////////////////////////////////////////
        {
            Invoke("InvokeSetCol", 0.5f + GridCell.intcrementVal);
            GridCell.intcrementVal+=0.5f;
        }
        void InvokeSetCol()//////////////////////////////////////////////////////////////////////////////////
        {
            this.gameObject.GetComponent<MeshRenderer>().material = checkedCol;
        }
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
            _cost = cost;
        }
        public int GetCost()
        {
            return _cost;
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