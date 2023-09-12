using Assets.Scripts.ClampManagerScripts;
using Assets.Scripts.InputManager;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CarMovement : MonoBehaviour
{
    IClampPlayerMovementManager _clampPlayerManager;
    IInputManager _inputManager;
    void Awake()
    {
        _inputManager = this.GetComponent<InputManager>();
        _clampPlayerManager = this.GetComponent<ClampPlayerMovementManager>();
    }
    void Update()
    {
        _inputManager.ManageInputs();
        _clampPlayerManager.ClampPlayerMovement();
    } 
}
