using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gorevCamControl : MonoBehaviour
{

    public GameObject lavuk;
    public GameObject gorev1Cam;
    

   void gorev1CamFinish()
    {
        lavuk.SetActive(true);
        gorev1Cam.SetActive(false);
    }

    void gorev2CamFinish()
    {
        lavuk.SetActive(true);
        gorev1Cam.SetActive(false);
    }
}
