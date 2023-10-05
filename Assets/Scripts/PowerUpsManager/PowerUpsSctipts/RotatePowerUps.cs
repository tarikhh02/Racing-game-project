using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUps : MonoBehaviour
{
    private void Update()
    {
        this.transform.Rotate(0, 0.1f, 0);
    }
}
