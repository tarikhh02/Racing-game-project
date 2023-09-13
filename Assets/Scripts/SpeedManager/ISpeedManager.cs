using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SpeedManager
{
    public interface ISpeedManager
    {
        void ManageSpeed(ref float speed, ref float steeringAngle);
    }
}
