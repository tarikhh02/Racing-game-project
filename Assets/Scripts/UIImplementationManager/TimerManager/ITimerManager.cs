using System.Collections;
using TMPro;
using UnityEngine;

namespace Race_game_project.TimerManager
{
    public interface ITimerManager
    {
        public void WriteTime();
        public int GetLap();
        public void ResetTimer();
    }
}