using Assets.Scripts.SpeedManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race_game_project.TrailManager
{
    public class ManageTrails : MonoBehaviour
    {
        [SerializeField]
        TrailRenderer _rightTrailRenderer;
        [SerializeField]
        TrailRenderer _leftTrailRenderer;
        ISpeedManager _speedManager;
        private void Awake()
        {
            _speedManager = this.GetComponent<SpeedManager>();
        }
        private void Update()
        {
            if(_speedManager.GetIsBreaking())
                SetTrailsEmitting(true);
            else
                SetTrailsEmitting(false);
        }
        private void SetTrailsEmitting(bool isEmitting)
        {
            _rightTrailRenderer.emitting = isEmitting;
            _leftTrailRenderer.emitting = isEmitting;
        }
    }
}
