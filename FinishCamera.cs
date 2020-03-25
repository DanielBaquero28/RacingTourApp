using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In charge of managing the camera when user has won
public class FinishCamera : MonoBehaviour
{ 
    void Update()
    {
        transform.Rotate(0,1,0,Space.World);   
    }
}
