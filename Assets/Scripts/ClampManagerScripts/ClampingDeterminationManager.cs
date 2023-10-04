using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ClampManagerScripts
{
    public class ClampingDeterminationManager : MonoBehaviour, IClampingDeterminationManager
    {
        //Can be made so object can see if it is on main track or dirt or something else so speed can be adjusted
        //Rays can be set to recognize track so in future if width of track changes we don't have to worry about it
        [SerializeField]
        float rayX = 0.2f;
        [SerializeField]
        float frontRayZ = 0.005f;
        [SerializeField]
        float backRayZ = 1.0f;
        public bool PlayerMovementNeedsToBeClamped()
        {
            Vector3 rightRayPosition = this.transform.forward * frontRayZ + this.transform.position + this.transform.right * rayX;
            Vector3 leftRayPosition = this.transform.forward * frontRayZ + this.transform.position + this.transform.right * -rayX;
            Vector3 rightBackRayPosition = -this.transform.forward * backRayZ + this.transform.position + this.transform.right * rayX;
            Vector3 leftBackRayPosition = -this.transform.forward * backRayZ + this.transform.position + this.transform.right * -rayX;
            if (HasCastedRayHitSomething(rightRayPosition)
                || HasCastedRayHitSomething(leftRayPosition)
                || HasCastedRayHitSomething(rightBackRayPosition)
                || HasCastedRayHitSomething(leftBackRayPosition))
            {
                return false;
            }
            return true;
        }
        private bool HasCastedRayHitSomething(Vector3 position)
        {
            RaycastHit hit;
            if (Physics.Raycast(position, -this.transform.up, out hit, 2f))
            {
                if(hit.collider.CompareTag("GridCell"))
                    return true;
            }
            return false;
        }
    }
}