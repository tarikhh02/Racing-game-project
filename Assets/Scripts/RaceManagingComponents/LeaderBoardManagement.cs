using Race_game_project.DeactivateCarManager;
using Race_game_project.CanvasSwithcingManager;
using Race_game_project.IdHandlingManager;
using Race_game_project.UIImplementationManager;
using System.Collections.Generic;
using UnityEngine;
using Race_game_project.FinishedMenuFiller;

namespace Race_game_project.LeaderBoardManager
{
    public class LeaderBoardManagement : MonoBehaviour, ILeaderBoardManagement
    {
        List<KeyValuePair<System.Guid, string>> _legendBoard = new List<KeyValuePair<System.Guid, string>>();
        bool _isRaceFinished = false;
        ICanvasSwitchManager _canvasSwithcer;
        IDeactivateCarManager _carDeactivation;
        IFinishMenuUIFiller _finishMenuUIFiller;
        private void Awake()
        {
            _canvasSwithcer = this.gameObject.GetComponent<CanvasSwitchManager>();
            _finishMenuUIFiller = this.gameObject.GetComponent<FinishMenuUIFiller>();
        }
        public void ManageLeaderBoard(List<ManageUI> listOfAllCars)
        {
            if (_isRaceFinished)
                return;
            foreach (var car in listOfAllCars)
            {
                var carInfo = KeyValuePair.Create(car.GetComponent<IdHandler>().GetId(), car.name);

                if (_legendBoard.Contains(carInfo))
                    continue;
                if (car.GetLap() >= 3)
                {
                    _legendBoard.Add(carInfo);
                    if (car.IsPlayer())
                    {
                        _carDeactivation = car.GetComponent<DeactivatePlayerCar>();
                        _carDeactivation.DeactivateCar(car);
                    }
                    else
                    {
                        _carDeactivation = car.GetComponent<DeactivateAICarManager>();
                        _carDeactivation.DeactivateCar(car);
                    }
                }
            }
            if (listOfAllCars.Count == _legendBoard.Count)
            {
                _canvasSwithcer.SwitchCanvas();
                _finishMenuUIFiller.FillFinishMenuUI(_legendBoard);
                _isRaceFinished = true;
            }
        }
    }
}