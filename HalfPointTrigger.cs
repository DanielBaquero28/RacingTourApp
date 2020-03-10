using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteTrigger;
    public GameObject HalfCompleteTrigger;

    void OnTriggerEnter()
    {
        LapCompleteTrigger.SetActive(true);
        HalfCompleteTrigger.SetActive(false);
    }
}