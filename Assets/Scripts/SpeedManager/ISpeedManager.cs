using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SpeedManager
{
    public interface ISpeedManager
    {
        public void ManageForwardMovement(float forwardDirection);
        public void MoveForward(ref float speed, ref float steeringAngle, float maxSteeringRotation, float forwardDirection);
        public void Break(ref float speed, ref float steeringAngle, float forwardDirection);
        public void IncrementSteerinAngle();
        public void ApplyDrag();
        public void AddToThrotle(float value);
        public void AddToBreakingForce(float value);
        public bool GetIsBreaking();
    }
}
