using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

// In charge of setting the CarControl Script Active when the Countdown is finished
public class CarControlActive : MonoBehaviour
{
    public GameObject CarControl;

    void Start()
    {
        CarControl.GetComponent<CarController>().enabled = true;    
    }
}
