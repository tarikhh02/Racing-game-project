using System.Collections;
using TMPro;
using UnityEngine;

namespace Race_game_project.ProgresCalculatingManager
{
    public interface IProgressCalculator
    {
        public void CalculateProgress(bool isPlayer, bool isGoingBackwards);
        public int GetProgress();
        public void ResetProgressCalculation();
    }
}