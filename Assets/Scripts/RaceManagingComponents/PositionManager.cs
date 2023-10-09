using Race_game_project.UIImplementationManager;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.PositionManager
{
    public class PositionManager : MonoBehaviour, IPositionManager
    {
        public void ManagePositions(List<ManageUI> listOfAllCars)
        {
            SortList(ref listOfAllCars);
            for (int i = 0; i < listOfAllCars.Count; i++)
            {
                if (listOfAllCars[i].IsPlayer())
                {
                    listOfAllCars[i].SetPosition(i + 1);
                }
            }
        }
        private void SortList(ref List<ManageUI> listOfAllCars)
        {
            for (int i = 0; i < listOfAllCars.Count; i++)
            {
                for (int j = 0; j < listOfAllCars.Count - 1; j++)
                {
                    if ((listOfAllCars[j].GetProgress() < listOfAllCars[j + 1].GetProgress() && listOfAllCars[j].GetLap() == listOfAllCars[j + 1].GetLap())
                        || listOfAllCars[j].GetLap() < listOfAllCars[j + 1].GetLap())
                    {
                        var temp = listOfAllCars[j];
                        listOfAllCars[j] = listOfAllCars[j + 1];
                        listOfAllCars[j + 1] = temp;
                    }
                }
            }
        }
    }
}