using Assets.Scripts.MovementManager;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Race_game_project.SpeedWritingManager
{
    public class SpeedWriter : MonoBehaviour, ISpeedWriter
    {
        [SerializeField]
        TextMeshProUGUI speedTxt;
        IObjectMover _objectMover;
        private void Awake()
        {
            _objectMover = GetComponent<ObjectMover>();
        }
        public void WriteSpeed()
        {
            int speed = (int)(_objectMover.GetSpeed() * 25);
            if (speed < 0)
                speed *= -1;
            speedTxt.text = "Speed: " + speed;
        }
    }
}