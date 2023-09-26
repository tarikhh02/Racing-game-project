using Assets.Scripts.GridCellManager;
using Race_game_project.AIPathFinderManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Race_game_project.CellForPathChooserComponent
{
    public class CellForPathChooser : MonoBehaviour, ICellForPathChooser
    {
        IGridCell _cell;
        public ref IGridCell ChooseCellForPath(ref List<IGridCell> cellsToChoose, ref float previousDistance, float scale, float speed)
        {
            bool isCellFound = true;
            _cell = cellsToChoose[0];
            cellsToChoose.RemoveAt(0);
            float currentDistance = previousDistance + scale + Math.Abs(_cell.GetDirection().x * _cell.GetDirection().z);
            var listOfCarsThatWillPass = _cell.GetListOfCarsThatWillPass();
            foreach (var car in listOfCarsThatWillPass)
            {
                if ((int)(currentDistance / (speed + 0.001f)) == (int)(car.Value.Item2 / (car.Value.Item1 + 0.001f)) 
                    && true) //Math.Abs(currentDistance - car.Value.Item2) <= this.transform.localScale.z / 2)
                {
                    isCellFound = false;
                    break;
                }
            }
            if (!isCellFound)
            {
                return ref ChooseCellForPath(ref cellsToChoose, ref previousDistance, scale, speed);
            }
            else
            {
                cellsToChoose.RemoveAll(remove => true);
                cellsToChoose.Clear();
                _cell.AddCarThatVillPass(this.GetComponent<AIShortestPathFinder>(), speed, currentDistance);
                return ref _cell;
            }
        }
    }
}