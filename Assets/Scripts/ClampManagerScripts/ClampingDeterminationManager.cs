using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ClampManagerScripts
{
    public class ClampingDeterminationManager : MonoBehaviour, IClampingDeterminationManager
    {
        //Can be made so object can see if it is on main track or dirt or something else so speed can be adjusted
        //Rays can be set to recognize track so in future if width of track changes we don't have to worry about it
        [SerializeField]
        float rayX = 0.35f;
        [SerializeField]
        float rayY = 0.03f;
        public bool PlayerMovementNeedsToBeClamped()
        {
            RaycastHit hit;
            Vector3 rightRayPosition = new Vector3
            {
                x = this.transform.localPosition.x + rayX,
                y = this.transform.localPosition.y + rayY,
                z = transform.localPosition.z,
            };
            Vector3 leftRayPosition = rightRayPosition;
            leftRayPosition.x -= 0.7f;
            if (Physics.Raycast(rightRayPosition, -this.transform.up, out hit, 2f)
                && Physics.Raycast(leftRayPosition, -this.transform.up, out hit, 2f))
            {
                return false;
            }
            return true;
        }
    }
}