using System.Collections;
using UnityEngine;

namespace Racing_game_project.AIDirectionSetter
{
    public class AIDirectionSettingManager : MonoBehaviour, IAIDirectionSettingManager
    {
        float _speedIncrement = 0;
        float _oldFwdDir = 0;
        public void SetDirections(ref float forwardDirection, ref int sideDirection, float currentSpeed, Vector3 direction, float maxSpeed)
        {
            float currentYAngle = this.transform.rotation.eulerAngles.y;
            float rotationAngle = Vector3.SignedAngle(this.transform.forward, direction, new Vector3(0, 1, 0));
            if ((int)rotationAngle == 0)
            {
                forwardDirection = SetForwardDirectionValue(1);
                sideDirection = 0;
            }
            else if (currentYAngle < rotationAngle + this.transform.eulerAngles.y)
            {
                SetForwardDirection(ref forwardDirection, currentSpeed, maxSpeed);
                sideDirection = 1;
            }
            else
            {
                SetForwardDirection(ref forwardDirection, currentSpeed, maxSpeed);
                sideDirection = -1;
            }
            print(_speedIncrement);
        }
        private float SetForwardDirectionValue(float forwardDirection)
        {
            if (_oldFwdDir != forwardDirection)
                _speedIncrement = 0;
            if (Mathf.Abs(forwardDirection) <= _speedIncrement)
                return forwardDirection;
            _speedIncrement += 0.1f;
            _oldFwdDir = forwardDirection;
             return forwardDirection * _speedIncrement;
        }

        private void SetForwardDirection(ref float forwardDirection, float currentSpeed, float maxSpeed)
        {
            if (currentSpeed > maxSpeed - 1)
                forwardDirection = SetForwardDirectionValue(-1);
            else
                forwardDirection = SetForwardDirectionValue(1);
        }
    }
}