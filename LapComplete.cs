using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MiliDisplay;

    public int LapDone;
    public float RawTimeLocal;

    public GameObject RaceFinish;

    void Update()
    {
        if (LapDone == 1)
        {
            RaceFinish.SetActive(true);
        }
    }

    void OnTriggerEnter()
    {
        LapDone += 1;
        RawTimeLocal = PlayerPrefs.GetFloat("RawTime");
        if (LapTimeManager.RawTime <= RawTimeLocal)
        {
            if (LapTimeManager.SecondCount <= 9)
            {
                SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
            }
            else
            {
                SecondDisplay.GetComponent<Text>().text = LapTimeManager.SecondCount + ".";
            }
            if (LapTimeManager.MinuteCount <= 9)
            {
                MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
            }
            else
            {
                MinuteDisplay.GetComponent<Text>().text = LapTimeManager.MinuteCount + ":";
            }

            MiliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount;
        }

        PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
        PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
        PlayerPrefs.SetFloat("MilliSave", LapTimeManager.MilliCount);
        PlayerPrefs.SetFloat("RawTime", LapTimeManager.RawTime);

        LapTimeManager.SecondCount = 0;
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.MilliCount = 0;

        HalfLapTrig.SetActive(false);
        LapCompleteTrig.SetActive(false);

    }
}