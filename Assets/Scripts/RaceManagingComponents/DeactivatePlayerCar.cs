using Race_game_project.UIImplementationManager;
using System.Collections;
using UnityEngine;

namespace Race_game_project.DeactivateCarManager
{
    public class DeactivatePlayerCar : MonoBehaviour, IDeactivateCarManager
    {
        [SerializeField]
        GameObject _cameraWithMapView;
        public void DeactivateCar(ManageUI car)
        {
            _cameraWithMapView.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}