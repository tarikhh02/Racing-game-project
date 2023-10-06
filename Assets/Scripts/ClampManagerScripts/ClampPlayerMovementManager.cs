using Assets.Scripts.ClampManagerScripts;
using Assets.Scripts.MovementManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ClampPlayerMovementManager : MonoBehaviour, IClampPlayerMovementManager
{
    IObjectMover _objecMoveComponent;
    IClampingDeterminationManager _clampManager;
    RaycastHit hit;
    private void Awake()
    {
        _objecMoveComponent = this.gameObject.GetComponent<ObjectMover>();
        _clampManager = this.GetComponent<ClampingDeterminationManager>();
    }
    public void ClampPlayerMovement()
    {
        if (_clampManager.PlayerMovementNeedsToBeClamped())
        {
            if (System.Math.Abs(_objecMoveComponent.GetSpeed()) > 0.1f)
            {
                if (_objecMoveComponent.GetSpeed() < 0)
                    _objecMoveComponent.GetSpeed() += 0.02f * _objecMoveComponent.GetMaxMovementSpeed() / 4;
                else
                    _objecMoveComponent.GetSpeed() -= 0.02f * _objecMoveComponent.GetMaxMovementSpeed() / 4;
            }
        }
    }
}
