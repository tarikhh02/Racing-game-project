using System.Collections;
using UnityEngine;

namespace Race_game_project.ObjectDisabler
{
    public class ObjectDisabler : MonoBehaviour
    {
        private void Update()
        {
            if (!this.GetComponent<ParticleSystem>().isPlaying)
            {
                this.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}