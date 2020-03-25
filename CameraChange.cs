using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In charge of managing the camera viewmode
public class CameraChange : MonoBehaviour
{
    public GameObject NormalCam;
    public GameObject FarCam;
    public GameObject FPCam;
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Viewmode"))
        {
            // If last viewmode is passed, reset it
            if (CamMode == 2)
            {
                CamMode = 0;
            }
            else
            {
                CamMode++;
            }
            StartCoroutine(ModeChange());
        }

    }
    IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            NormalCam.SetActive(true);
            FPCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            FarCam.SetActive(true);
            NormalCam.SetActive(false);
        }
        if (CamMode == 2)
        {
            FPCam.SetActive(true);
            FarCam.SetActive(false);
        }
    }
}
