using System.Collections;
using UnityEngine;

namespace Race_game_project.UIImplementationManager
{
    public interface IManageUI
    {
        public int GetProgress();
        public int GetLap();
        public bool IsPlayer();
        public void ResetTracking();
    }
}