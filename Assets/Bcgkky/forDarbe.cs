using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forDarbe : MonoBehaviour
{

  
    void Update()
    {
        // transform.Translate(transform.forward * Time.deltaTime * 10f);
        transform.Translate(Vector3.forward * 20f * Time.deltaTime);
        Destroy(gameObject,.20f);


        //buuuuuug buuuuug buuuug buuuug lanet olas�u buuuuguuguguguug 
    }
}
