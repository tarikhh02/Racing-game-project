using Race_game_project.UIImplementationManager;
using Race_game_project.LeaderBoardManager;
using Race_game_project.PositionManager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Race_game_project.RaceManagingComponent
{
    public class RaceManager : MonoBehaviour
    {
        IPositionManager _positionManager;
        ILeaderBoardManagement _leaderBoardManagement;
        List<ManageUI> _listOfAllCars;
        private void Awake()
        {
            _positionManager = this.GetComponent<PositionManager.PositionManager>();
            _leaderBoardManagement = this.GetComponent<LeaderBoardManagement>();
            _listOfAllCars = FindObjectsByType<ManageUI>(FindObjectsSortMode.None).ToList();
        }
        private void Update()
        {
            _positionManager.ManagePositions(_listOfAllCars);
            _leaderBoardManagement.ManageLeaderBoard(_listOfAllCars);
        }
    }
}