using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Race_game_project.FinishedMenuFiller
{
    public class FinishMenuUIFiller : MonoBehaviour, IFinishMenuUIFiller
    {
        [SerializeField]
        TextMeshProUGUI _firstPlace;
        [SerializeField]
        TextMeshProUGUI _secondPlace;
        [SerializeField]
        TextMeshProUGUI _thirdPlace;
        [SerializeField]
        TextMeshProUGUI _restOfCars;
        public void FillFinishMenuUI(List<KeyValuePair<Guid, string>> legendBoard)
        {
            for (int i = 0; i < legendBoard.Count; i++)
            {
                if (i == 0)
                    _firstPlace.text = GetStringFromCar(i, legendBoard[i].Value);
                else if (i == 1)
                    _secondPlace.text = GetStringFromCar(i, legendBoard[i].Value);
                else if (i == 2)
                    _thirdPlace.text = GetStringFromCar(i, legendBoard[i].Value);
                else
                    _restOfCars.text += GetStringFromCar(i, legendBoard[i].Value.ToString() + "\n");
            }
        }
        private string GetStringFromCar(int position, string name)
        {
            return position + 1 + ". " + name;
        }
    }
}