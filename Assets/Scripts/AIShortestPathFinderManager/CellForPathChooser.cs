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
        public IGridCell ChooseCellForPath(ref List<IGridCell> cellsToChoose, ref float previousDistance, float scale, float speed)
        {
            bool isCellFound = true;
            IGridCell cell = cellsToChoose[0];
            cellsToChoose.RemoveAt(0);
            float currentDistance = previousDistance + scale + Math.Abs(cell.GetDirection().x * cell.GetDirection().z);
            var listOfCarsThatWillPass = cell.GetListOfCarsThatWillPass();
            foreach (var car in listOfCarsThatWillPass)
            {
                if ((int)(currentDistance / (speed + 0.001f)) == (int)(car.Value.Item2 / (car.Value.Item2 + 0.001f)))
                {
                    isCellFound = false;
                    break;
                }
            }
            if (!isCellFound)
            {
                return ChooseCellForPath(ref cellsToChoose, ref previousDistance, scale, speed);
            }
            else
            {
                cellsToChoose.RemoveAll(remove => true);
                cellsToChoose.Clear();
                cell.AddCarThatVillPass(this.GetComponent<AIShortestPathFinder>(), speed, currentDistance);
                return cell;
            }
        }
    }
}