using Race_game_project.UIImplementationManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.DeactivateCarManager
{
    public class DeactivatePlayerCar : MonoBehaviour, IDeactivateCarManager
    {
        [SerializeField]
        GameObject _cameraWithMapView;
        IActivateAIAudio _audioActivator;
        public void DeactivateCar(ManageUI car)
        {
            _audioActivator = this.GetComponent<ActivateAIAudio>();
            _audioActivator.ActivateAIAutdio();
            _cameraWithMapView.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}