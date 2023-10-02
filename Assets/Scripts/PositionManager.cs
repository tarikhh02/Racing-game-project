using Race_game_project.TimerManager;
using Race_game_project.UIImplementationManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Race_game_project.PositionManagingComponent
{
    public class PositionManager : MonoBehaviour
    {
        List<ManageUI> _listOfAllCars;
        private void Awake()
        {
            _listOfAllCars = FindObjectsByType<ManageUI>(FindObjectsSortMode.None).ToList();
        }
        private void Update()
        {
            ManagePositions();
        }

        private void ManagePositions()
        {
            for (int i = 0; i < _listOfAllCars.Count; i++)
            {
                for (int j = 0; j < _listOfAllCars.Count - 1; j++)
                {
                    if ((_listOfAllCars[j].GetProgress() < _listOfAllCars[j + 1].GetProgress() && _listOfAllCars[j].GetLap() == _listOfAllCars[j + 1].GetLap())
                        || _listOfAllCars[j].GetLap() < _listOfAllCars[j + 1].GetLap())
                    {
                        var temp = _listOfAllCars[j];
                        _listOfAllCars[j] = _listOfAllCars[j + 1];
                        _listOfAllCars[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < _listOfAllCars.Count; i++)
            {
                if (_listOfAllCars[i].IsPlayer())
                {
                    _listOfAllCars[i].SetPosition(i + 1);
                }
            }
        }
    }
}