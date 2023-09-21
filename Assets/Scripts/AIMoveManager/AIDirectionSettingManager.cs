using System.Collections;
using UnityEngine;

namespace Racing_game_project.AIDirectionSetter
{
    public class AIDirectionSettingManager : MonoBehaviour, IAIDirectionSettingManager
    {
        public void SetDirections(ref int forwardDirection, ref int sideDirection, float currentSpeed, Vector3 direction)
        {
            float currentYAngle = this.transform.rotation.eulerAngles.y;
            float rotationAngle = Vector3.SignedAngle(this.transform.forward, direction, new Vector3(0, 1, 0));
            if ((int)rotationAngle == 0)
            {
                forwardDirection = 1;
                sideDirection = 0;
            }
            else if (currentYAngle < rotationAngle + this.transform.eulerAngles.y)
            {
                if (currentSpeed > 3f)
                    forwardDirection = -1;
                else
                    forwardDirection = 1;
                sideDirection = 1;
            }
            else
            {
                if (currentSpeed > 3f)
                    forwardDirection = -1;
                else
                    forwardDirection = 1;
                sideDirection = -1;
            }

        }
    }
}