using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SpeedManager
{
    public interface ISpeedManager
    {
        public void ManageForwardMovement(int forwardDirection);
        public void MoveForward(ref float speed, ref float steeringAngle, float maxSteeringRotation, int forwardDirection);
        public void Break(ref float speed, ref float steeringAngle, int forwardDirection);
        public void IncrementSteerinAngle();
        public void ApplyDrag();
    }
}
