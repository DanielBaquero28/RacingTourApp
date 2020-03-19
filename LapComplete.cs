using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MiliDisplay;

    public int LapDone = 0;
    public float RawTimeLast;

    public GameObject RaceFinish;

    public int RawLastSec;
    public static float BestTime;

    void OnTriggerEnter()
    {
        LapDone += 1;
        RawTimeLast = PlayerPrefs.GetFloat("RawTime");
        if (LapTimeManager.RawTime <= RawTimeLast)
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
            PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
            PlayerPrefs.SetFloat("MilliSave", 0);
            PlayerPrefs.SetFloat("RawTime", LapTimeManager.RawTime);
        }
        else
        {
            PlayerPrefs.SetFloat("RawTime", RawTimeLast);
            PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
            RawLastSec = (int)RawTimeLast;
            PlayerPrefs.SetInt("SecSave", RawLastSec);
            PlayerPrefs.SetFloat("MilliSave", 0);
        }

        BestTime = PlayerPrefs.GetFloat("RawTime");
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.MilliCount = 0;
        LapTimeManager.RawTime = 0.0f;

        HalfLapTrig.SetActive(false);
        LapCompleteTrig.SetActive(false);

    }

    void Update()
    {
        if (LapDone == 1)
        {
            RaceFinish.SetActive(true);
        }

        if (LapTimeManager.RawTime >= 60.5f)
        {
            SceneManager.LoadScene(7);
            RaceFinish.SetActive(true);
            LapTimeManager.MilliCount = 0.0f;
            LapTimeManager.SecondCount = 0;
            LapTimeManager.MinuteCount = 0;
            LapTimeManager.RawTime = 0.0f;
        }
    }
}
