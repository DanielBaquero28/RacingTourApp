using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RaceTimeManager : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MiliCount;

    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MiliDisplay;

    void Start()
    {
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MiliCount = PlayerPrefs.GetFloat("MiliSave");
        if (MinCount < 10)
        {
            MinDisplay.GetComponent<Text>().text = "0" + MinCount + ":";
        }
        else
        {
            MinDisplay.GetComponent<Text>().text = MinCount + ":";
        }
        if (SecCount < 10)
        {
            SecDisplay.GetComponent<Text>().text = "0" + SecCount + ".";
        }
        else
        {
            SecDisplay.GetComponent<Text>().text = SecCount + ".";
        }
        MiliDisplay.GetComponent<Text>().text = "" + MiliCount;
    }
}