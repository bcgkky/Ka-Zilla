using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bcgkky : MonoBehaviour
{

    public Slider forMutlulukBar;
    float yavass;
    float yavassS;
    bool cd = true;
    float beklemeSuresi = 0;
    float basmaSure = 0;
    public Image fillV;
    public Image fillR;

    public AudioSource mirmirSource;
    private AudioClip mirmirr;



    public GameObject patot;
    public GameObject darbe;
    public GameObject spawn;
    public GameObject cam;
    


    void Update()
    {
 //     
 //     RaycastHit hit;
 //   
 //    if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
 //    {
 //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
 //        Debug.Log("RAYCAAAAAAAAAAAAAAST");
 //        Debug.Log(hit.transform.tag);
 //
 //    }


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("sol t�k");
            StartCoroutine(darbeGo());
        }
         
         
        if (Input.GetKeyDown(KeyCode.R) && Time.time > yavassS)
        {

            fillR.fillAmount = 0;
            yavassS = Time.time + 5;
            StartCoroutine(kokuR());
        }

      if (Input.GetKeyDown(KeyCode.V) && Time.time > yavass)
        {
            Debug.Log("oluo");
            fillV.fillAmount = 0;
          yavass = Time.time + 5;
          forMutlulukBar.value += .1f;
            StartCoroutine(mirmir());
            
        }

        if (fillV.fillAmount == 0 || fillV.fillAmount > 0)
        {
            fillV.fillAmount += .2f * Time.deltaTime;
        } 
        
        if (fillR.fillAmount == 0 || fillR.fillAmount > 0)
        {
            fillR.fillAmount += .2f * Time.deltaTime;
        }

    }
    
	
	
    IEnumerator kokuR()
    {
        yield return new WaitForSeconds(.5f);
        patot.SetActive(true);
        yield return new WaitForSeconds(4f);
        patot.SetActive(false);

    }
    
    IEnumerator mirmir()
    {
        mirmirSource.Play();
        yield return new WaitForSeconds(5f);
        mirmirSource.Stop();
    } 
    
   IEnumerator darbeGo()
   {
        //darbe.transform.position = this.transform.position;
        //darbe.transform.rotation = this.transform.rotation;

       Instantiate(darbe, spawn.transform.position, spawn.transform.rotation);
        yield return new WaitForSeconds(.8f);
        darbe.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(.19f);
        darbe.GetComponent<BoxCollider>().enabled = false;


        //darbe.transform.position = spawn.transform.position;
        //darbe.transform.rotation = spawn.transform.rotation;

    }
}
