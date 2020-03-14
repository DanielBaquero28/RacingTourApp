using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class RaceFinish : MonoBehaviour
{
    public GameObject MyCar;
    public GameObject FinishCam;
    public GameObject ViewModes;
    public GameObject LevelMusic;

    public GameObject CompleteTrigger;
    public AudioSource FinishMusic;
    public GameObject LapTimeScript;

    public GameObject RetryButton;
    public GameObject MainMenuButton;
    public GameObject YouWinText;

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        MyCar.SetActive(false);
        CompleteTrigger.SetActive(false);
        CarController.m_Topspeed = 0.0f;
        MyCar.GetComponent<CarController>().enabled = false;
        MyCar.GetComponent<CarUserControl>().enabled = false;
        MyCar.SetActive(true);
        FinishCam.SetActive(true);
        LevelMusic.SetActive(false);
        ViewModes.SetActive(false);
        FinishMusic.Play();
        LapTimeScript.GetComponent<LapTimeManager>().enabled = false;
	RetryButton.SetActive(false);
	MainMenuButton.SetActive(true);
	YouWinText.SetActive(true);
    }

}
