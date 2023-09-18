using Assets.Scripts.GridCellManager;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.AIMoveManager
{
    public class AIPlaceHolderMove : MonoBehaviour
    {
        public Vector3 direction = new Vector3();
        bool arrived = false;
        RaycastHit hit;
        private void Update()
        {
            Debug.DrawRay(transform.position, -transform.up * 1f, Color.red, 1f);
            if (!arrived && Physics.Raycast(this.transform.position, -this.transform.up, out hit, 0.5f))
            {
                if (hit.collider.gameObject.tag == "GridCell")
                {   
                    direction = hit.collider.gameObject.GetComponent<GridCell>().GetDirection();
                }
                this.transform.position += direction * Time.deltaTime * 1f;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "End")
            {
                arrived = true;
                direction = new Vector3(0,0,0);
            }
        }
    }
}