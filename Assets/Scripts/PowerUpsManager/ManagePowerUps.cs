using Assets.Scripts.MovementManager;
using Assets.Scripts.SpeedManager;
using System.Collections;
using UnityEngine;
namespace Race_game_project.PowerUpsManager
{
    public class ManagePowerUps : MonoBehaviour
    {
        public bool isUsingPowerUp = false;
        float _timer;
        PowerUpBase powerUp;
        IObjectMover _moveObjectComponent;
        ISpeedManager _speedManager;
        private void Awake()
        {
            _moveObjectComponent = this.GetComponent<ObjectMover>();
            _speedManager = this.GetComponent<SpeedManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("MaxSpeedIncrementPowerUp") && !isUsingPowerUp)
            {
                powerUp = new MaxSpeedIncreasePowerUp(_speedManager, _moveObjectComponent);
                StartpowerUp(other.gameObject);
            }
            else if(other.CompareTag("ThrotleIncrementPowerUp") && !isUsingPowerUp)
            {
                powerUp = new ThrotleIncrementPowerUp(_speedManager, _moveObjectComponent);
                StartpowerUp(other.gameObject);
            }
        }
        private IEnumerator AddTimer()
        {
            yield return new WaitForSeconds(1);
            _timer += 1f;
            if (_timer < 5)
                StartCoroutine(nameof(AddTimer));
            else
            {
                _timer = 0;
                powerUp.ResetPowerUpValues();
                isUsingPowerUp = false;
            }
        }
        private void StartpowerUp(GameObject powerUpObj)
        {
            powerUp.ImplementPowerUpValues();
            StartCoroutine(nameof(AddTimer));
            powerUpObj.SetActive(false);
            powerUpObj.transform.parent.GetChild(1).gameObject.SetActive(true);
            isUsingPowerUp = true;
        }
    }
}