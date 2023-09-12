using Assets.Scripts.ClampManagerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPlayerMovementManager : MonoBehaviour, IClampPlayerMovementManager
{
    Vector3 _lastPos;
    IClampingDeterminationManager _clampManager;
    private void Awake()
    {
        _clampManager = this.GetComponent<ClampingDeterminationManager>();
        _lastPos = transform.localPosition;
    }
    public void ClampPlayerMovement()
    {
        if (_clampManager.PlayerMovementNeedsToBeClamped())
        {
            this.transform.position = _lastPos;
        }
        else
        {
            _lastPos = this.transform.position;
        }
    }
}
