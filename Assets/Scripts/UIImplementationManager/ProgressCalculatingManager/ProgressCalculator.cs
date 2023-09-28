using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Race_game_project.ProgresCalculatingManager
{
    public class ProgressCalculator : MonoBehaviour, IProgressCalculator
    {
        [SerializeField]
        TextMeshProUGUI raceProgress;
        int _progress;
        public void CalculateProgress(Transform start, Transform halfTrack, Transform secondStart, Transform end, bool goingBackwards, bool _hasPassedHalfTrack, bool isPlayer)
        {
            if (goingBackwards)
            {
                raceProgress.text = "Progress: 0%";
                return;
            }
            float progress;
            if (!_hasPassedHalfTrack)
            {
                progress = Vector3.Distance(this.transform.position, halfTrack.position);
                progress = 50 - (progress / 2 / Vector3.Distance(start.position, halfTrack.position) * 100);
            }
            else
            {
                progress = Vector3.Distance(this.transform.position, end.position);
                progress = 100 - (progress / 2 / Vector3.Distance(secondStart.position, end.position) * 100);
            }
            _progress = (int)progress;
            if (isPlayer)
                raceProgress.text = "Progress: " + _progress + "%";
        }
        public int GetProgress()
        {
            return _progress;
        }
    }
}