using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public interface IInputManager
    {
        public void ManageInputs();
        public void GetKeys();
    }
}