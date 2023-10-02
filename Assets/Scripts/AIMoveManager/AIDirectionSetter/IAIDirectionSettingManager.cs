using System.Collections;
using UnityEngine;

namespace Racing_game_project.AIDirectionSetter
{
    public interface IAIDirectionSettingManager
    {
        void SetDirections(ref float forwardDirection, ref int sideDirection, float currentSpeed, Vector3 direction, float maxSpeed);
    }
}