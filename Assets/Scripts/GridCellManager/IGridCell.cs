using Race_game_project.AIPathFinderManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

namespace Assets.Scripts.GridCellManager
{
    public interface IGridCell
    {
        public void SetUpCell(Transform parent, int y, int x);
        public int GetX();
        public int GetY();
        public bool GetChecked();
        public Vector3 GetDirection();
        public void SetCost(int cost);
        public int GetCost();
        public void SetCostIncrementValue(int costIncrementValue);
        public void SetDirection(Vector3 direction);
        public GameObject GetGameObject();
        public List<KeyValuePair<IAIShortestPathFinder, Tuple<float, float>>> GetListOfCarsThatWillPass();
        public void AddCarThatVillPass(IAIShortestPathFinder car, float speed, float distance);

    }
}