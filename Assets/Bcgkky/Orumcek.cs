using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orumcek : MonoBehaviour
{

    NavMeshAgent ag;
    public GameObject lavuk;
    Animator anim;
    public int can = 4;
    public AudioSource au;
    public float mesafe;


    void Start()
    {
        ag = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        float dist = Vector3.Distance(gameObject.transform.position, lavuk.transform.position);

        if (dist < mesafe)
        {
            ag.SetDestination(lavuk.transform.position);
            anim.SetBool("walk", true);
            GameObject.FindGameObjectWithTag("border").GetComponent<SliderControl>().korku.value += .2f * Time.deltaTime;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().korku += .2f * Time.deltaTime;
        }
        if (dist > mesafe)
        {
            anim.SetBool("walk", false);
        }

        if (can == 0)
        {
            anim.SetBool("geberdi", true);
            GetComponent<NavMeshAgent>().enabled= false;
            GetComponent<CapsuleCollider>().enabled= false;
            Destroy(gameObject,4f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("darbe"))
        {
            au.Play();
            anim.SetTrigger("dmg");
            Debug.Log("yavas la yavas gac tane atýyon");
            can--;
        }
    }


}
