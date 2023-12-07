using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gorevComplateSprite : MonoBehaviour
{


    public GameObject kapi;
    public GameObject kapi2;
    public AudioSource au;

    public GameObject grv;
    public Image gorevBitti_2;
    


    private void OnTriggerEnter(Collider other)
    {
      // if (other.gameObject.CompareTag("davuk") && this.CompareTag("gorev1ok"))
      // {
      //
      //     kapi.GetComponent<Animator>().SetBool("open",true);
      //     au.Play();
      //     this.GetComponent<SpriteRenderer>().enabled= false;
      //     Destroy(gameObject,1.5f);
      // }
        if (other.gameObject.CompareTag("Player") && this.CompareTag("gorev2ok"))
        {
            grv.GetComponent<TextMeshProUGUI>().color = Color.green;
            kapi.GetComponent<Animator>().Play("kapi2anim2");
            this.GetComponent<SpriteRenderer>().enabled = false;
            au.Play();
            gorevBitti_2.gameObject.SetActive(true);
            gorevBitti_2.GetComponent<Image>().color = Color.green;
            kapi2.GetComponent<Animator>().Play("kapi3anim");
            Destroy(gameObject,1.5f);
        }
    }
}
