using Assets.Scripts.ClampManagerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPlayerMovementManager : MonoBehaviour, IClampPlayerMovementManager
{
    Vector3 _lastPos;
    Quaternion _lastRotation;
    IClampingDeterminationManager _clampManager;
    RaycastHit hit;
    private void Awake()
    {
        _clampManager = this.GetComponent<ClampingDeterminationManager>();
        _lastPos = transform.localPosition;
        _lastRotation = transform.rotation;
    }
    public void ClampPlayerMovement()
    {
        if (_clampManager.PlayerMovementNeedsToBeClamped(ref hit))
        {
            this.transform.position = _lastPos;
            this.transform.rotation = _lastRotation;
        }
        else
        {
            _lastPos = this.transform.position;
            _lastRotation = this.transform.rotation;
        }
    }
}
