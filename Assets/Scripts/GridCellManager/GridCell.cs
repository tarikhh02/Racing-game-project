using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Scripts.GridInitializer;
using Assets.Scripts.PathFindingManager;
using System.Data;
using Race_game_project.AIPathFinderManager;

namespace Assets.Scripts.GridCellManager
{
    [ExecuteInEditMode]
    public class GridCell : MonoBehaviour, IGridCell
    {
        public List<KeyValuePair<IAIShortestPathFinder, Tuple<float, float>>> _carsThatWillPass = new List<KeyValuePair<IAIShortestPathFinder, Tuple<float, float>>>();
        public int _x;
        public int _y;
        public int _cost;
        int _costIncrementValue = 1;
        public Vector3 direction;
        bool _isChecked = false;
        public void SetUpCell(Transform parent, int y, int x)
        {
            this.gameObject.tag = "GridCell";
            _x = x;
            _y = y;
            this.gameObject.transform.SetParent(parent);
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
            return direction;
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
            this.direction = direction;
        }
        public GameObject GetGameObject()
        {
            return this.gameObject;
        }
        public List<KeyValuePair<IAIShortestPathFinder, Tuple<float, float>>> GetListOfCarsThatWillPass()
        {
            return _carsThatWillPass;
        }
        public void AddCarThatVillPass(IAIShortestPathFinder car, float speed, float distance)
        {
            _carsThatWillPass.Add(KeyValuePair.Create(car, Tuple.Create(speed, distance)));
        }
    }
}