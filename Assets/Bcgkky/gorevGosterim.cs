using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gorevGosterim : MonoBehaviour
{

    public GameObject lavuk;
    public GameObject gorevCam;
    public GameObject kapi2;
    public GameObject gorev1ok;
    public Image gorevBitmedi;
    public AudioSource au;
    
    public GameObject grv;

    public float textTransparency = 0.5f;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.CompareTag("gorev1"))
        {
            
            au.Play();
            lavuk.SetActive(false);
            grv.gameObject.SetActive(true);
            Color textColor = grv.GetComponent<TextMeshProUGUI>().color;
            textColor.a = textTransparency;
            grv.GetComponent<TextMeshProUGUI>().color = textColor;
            gorevCam.SetActive(true);
            gorevBitmedi.gameObject.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("gorev1_1").GetComponent<MeshRenderer>().enabled = true;
            Destroy(gameObject,1f);
        }
        if (other.gameObject.CompareTag("Player") && this.CompareTag("gorev2"))
        {
            au.Play();
            lavuk.SetActive(false);
            grv.gameObject.SetActive(true);
            Color textColor = grv.GetComponent<TextMeshProUGUI>().color;
            textColor.a = textTransparency;
            grv.GetComponent<TextMeshProUGUI>().color = textColor;
            this.GetComponent<MeshRenderer>().enabled = false;
            gorevCam.SetActive(true);
            gorevBitmedi.gameObject.SetActive(true);
            kapi2.GetComponent<Animator>().Play("kapi2anim");
            Destroy(gameObject,1f);
        }
        if (other.gameObject.CompareTag("Player") && this.CompareTag("gorev3"))
        {
            au.Play();
            lavuk.SetActive(false);
            grv.gameObject.SetActive(true);
            gorevCam.SetActive(true);
            Color textColor = grv.GetComponent<TextMeshProUGUI>().color;
            textColor.a = textTransparency;
            grv.GetComponent<TextMeshProUGUI>().color = textColor;
            gorevBitmedi.gameObject.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject,1f);
        }
        if (other.gameObject.CompareTag("Player") && this.CompareTag("gorev1_1"))
        {
            au.Play();
            lavuk.SetActive(false);
            gorev1ok.SetActive(true);
            GameObject.FindGameObjectWithTag("davuk").GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled =false;
            gorevCam.SetActive(true);
            Destroy(gameObject,1f);
        }
    }
}
