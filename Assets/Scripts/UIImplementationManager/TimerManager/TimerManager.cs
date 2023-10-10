using System.Collections;
using TMPro;
using UnityEngine;

namespace Race_game_project.TimerManager
{
    public class TimerManager : MonoBehaviour, ITimerManager
    {
        [SerializeField]
        TextMeshProUGUI lapTime;
        [SerializeField]
        TextMeshProUGUI lap;
        int _lapNumber = 0;
        float _timer;
        private void Awake()
        {
            StartCoroutine(nameof(AddTime));
        }
        private IEnumerator AddTime()
        {
            yield return new WaitForSeconds(0.01f);
            _timer += 0.01f;
            StartCoroutine(nameof(AddTime));
        }
        private string ConvertToStringForUI(int number)
        {
            if (number > 9)
                return number.ToString();
            else
                return " " + number.ToString();
        }
        private void WriteLap()
        {
            lap.text = "Lap: "+ _lapNumber + "/3";
        }
        public void WriteTime()
        {
            var timer = _timer;
            int minutes = (int)(timer / 60);
            timer -= minutes * 60;
            int seconds = (int)timer;
            timer -= seconds;
            int miliseconds = (int)(timer * 100);
            lapTime.text = "Lap time:" + ConvertToStringForUI(minutes) + ":" + ConvertToStringForUI(seconds) + ":" + ConvertToStringForUI(miliseconds);
        }
        public void ResetTimer()
        {
            _timer = 0;
            _lapNumber++;
            if (lap != null)
                WriteLap();
        }
        public int GetLap()
        {
            return _lapNumber;
        }
    }
}