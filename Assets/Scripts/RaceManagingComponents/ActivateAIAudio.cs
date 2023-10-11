using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAIAudio : MonoBehaviour, IActivateAIAudio
{
    public void ActivateAIAutdio()
    {
        var listOfCars = FindObjectsByType<AudioManagement>(FindObjectsSortMode.None);
        foreach (var car in listOfCars) 
        {
            car.enabled = true;
        }
    }
}
