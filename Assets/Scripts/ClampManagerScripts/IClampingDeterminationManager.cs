using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.ClampManagerScripts
{
    public interface IClampingDeterminationManager
    {
        public bool PlayerMovementNeedsToBeClamped(ref RaycastHit hit);
    }
}