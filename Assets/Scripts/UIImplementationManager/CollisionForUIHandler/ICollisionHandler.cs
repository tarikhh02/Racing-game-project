using System.Collections;
using UnityEngine;

namespace Race_game_project.CollisionForUIHandler
{
    public interface ICollisionHandler
    {
        public bool GetHasPassedHalfTrack();
        public bool GetIsGoingBackwards();
        public void ResetMovementTrackers();
    }
}