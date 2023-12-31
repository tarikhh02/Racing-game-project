﻿using Race_game_project.WayPointManager;
using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Race_game_project.ProgresCalculatingManager
{
    public class ProgressCalculator : MonoBehaviour, IProgressCalculator
    {
        [SerializeField]
        TextMeshProUGUI _raceProgress;
        [SerializeField]
        GameObject _currentWayPoint;
        [SerializeField]
        GameObject _nextWayPoint;
        GameObject _currentWayPoitChangeable;
        GameObject _nextWayPointChangeable;
        int _wayPointsNumber = 9;
        int _currentWayPointNumber = 0;
        int _progress;
        private void Awake()
        {
            ResetProgressCalculation();
        }
        public void CalculateProgress(bool isPlayer, bool _isGoingBackwards)
        {
            if(_isGoingBackwards)
            {
                if(isPlayer)
                    _raceProgress.text = "Progress: 0%";
                return;
            }
            float totalDistance = Vector3.Distance(_currentWayPoitChangeable.transform.position, _nextWayPointChangeable.transform.position);
            float progress = (totalDistance - Vector3.Distance(this.transform.position, _nextWayPointChangeable.transform.position)) / totalDistance;
            progress = _currentWayPointNumber * (100 / _wayPointsNumber) + (progress * 100) / _wayPointsNumber;
            if (_progress < progress) 
                _progress = (int)progress;
            if(isPlayer)
            {
                _raceProgress.text = "Progress: " + _progress + "%";
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("WayPoint"))
            {
                IWayPoint wayPoint = other.gameObject.GetComponent<WayPoint>();
                _currentWayPoitChangeable = other.gameObject;
                _nextWayPointChangeable = wayPoint.GetNextWayPoint();
                _currentWayPointNumber = wayPoint.GetWayPointIndex();
                if(_currentWayPointNumber == 0)
                    _progress = 0;
            }
        }
        public int GetProgress()
        {
            return _progress;
        }
        public void ResetProgressCalculation()
        {
            _currentWayPoitChangeable = _currentWayPoint;
            _nextWayPointChangeable = _nextWayPoint;
            _currentWayPointNumber = 0;
            _progress = 0;
        }
    }
}