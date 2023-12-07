using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildiriTakip : MonoBehaviour
{

    [SerializeField]
    GameObject lavuk;

    void Update()
    {
        gameObject.transform.LookAt(lavuk.transform.position);
    }
}
