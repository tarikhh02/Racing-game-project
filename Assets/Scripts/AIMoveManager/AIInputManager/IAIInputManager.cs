using System.Collections;
using UnityEngine;

namespace Racing_game_project.AIInputManager
{
    public interface IAIInputManager
    {
        public void ManageAIInputData();
        public Vector3 GetCurrentDirection();
        public void SetDirection(Vector3 direction);
        public void SetArrived(bool arrived);
        public float GetSideDirection();
    }
}