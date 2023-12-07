using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ForCamera : MonoBehaviour
{
    public GameObject thirdCam;
    public GameObject firstCam;
    public GameObject cat;
    public GameObject grv;
    public AudioSource au;
    public Image gorevBıttı;
    public GameObject gameFinish;

    public int camMode;

    
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            grv.GetComponent<TextMeshProUGUI>().color = Color.green;
            gorevBıttı.gameObject.SetActive(true);
            gorevBıttı.GetComponent<Image>().color = Color.green;
            au.Play();
            
            if (camMode == 0)
            {
                camMode = 1;
            }
            else
            {
                camMode = 0;
            }

            StartCoroutine(SwitchCamera());
            cat.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled= false;
            StartCoroutine(FinishGame());
            Destroy(gameObject, 1.5f);

        }
    }

    IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(.01f);
        if (camMode == 0)
        {
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
        }
        if(camMode == 1)
        {
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
        }
    }

    IEnumerator FinishGame()
    {
        if (camMode == 0)
        {
            gameFinish.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            gameFinish.SetActive(false);
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Deneme");
        }
    }
}
