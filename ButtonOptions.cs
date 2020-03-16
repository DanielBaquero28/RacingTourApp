using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOptions : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.MilliCount = 0;
        LapTimeManager.RawTime = 0.0f;
    }

    public void TrackSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(2);
    }

    public void RaceGoal()
    {
        SceneManager.LoadScene(4);
    }

    public void SignUp()
    {
	SceneManager.LoadScene(5);
    }

    public void LoginUser()
    {
	SceneManager.LoadScene(6);
    }

    public void Quit()
    {
        Application.Quit();
    }
    // Track Selector Options
    public void Track01()
    {
        SceneManager.LoadScene(2);
    }
}
