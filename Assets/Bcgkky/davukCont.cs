using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class davukCont : MonoBehaviour
{

    public AudioSource au;
    public AudioSource au1;

    public GameObject kapi;
    public GameObject gorev1ok;

    public GameObject grv;
    public Image gorevBitti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            au.Play();
            this.GetComponent<Animator>().Play("davukAnim");
            this.GetComponent<SphereCollider>().enabled= false;
            StartCoroutine(Gorev1ok());
        }
    }


    IEnumerator Gorev1ok()
    {
        yield return new WaitForSeconds(.40f);
        grv.GetComponent<TextMeshProUGUI>().color = Color.green;
        gorevBitti.gameObject.SetActive(true);
        gorevBitti.GetComponent<Image>().color = Color.green;
        kapi.GetComponent<Animator>().SetBool("open", true);
        au1.Play();
        gorev1ok.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gorev1ok, 1.5f);
    }
}
