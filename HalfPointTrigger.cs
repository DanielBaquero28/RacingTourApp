using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages triggers when the halfpoint of the race is reached 
public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteTrigger;
    public GameObject HalfCompleteTrigger;

    void OnTriggerEnter ()
    {
        LapCompleteTrigger.SetActive(true);
        HalfCompleteTrigger.SetActive(false);
    }
}
