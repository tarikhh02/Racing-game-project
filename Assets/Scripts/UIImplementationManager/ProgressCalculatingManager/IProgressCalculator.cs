using System.Collections;
using TMPro;
using UnityEngine;

namespace Race_game_project.ProgresCalculatingManager
{
    public interface IProgressCalculator
    {
        public void CalculateProgress(Transform start, Transform halfTrack, Transform secondStart, Transform end, bool goingBackwards, bool _hasPassedHalfTrack, bool isPlayer);
        public int GetProgress();
    }
}