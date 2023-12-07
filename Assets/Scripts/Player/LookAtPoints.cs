using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPoints : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public float lookDuration = 5.0f; // Belirli bir süre boyunca bakma süresi
    public float idleDuration = 2.0f; // Hareketsiz kalma süresi

    public bool isLooking = false;
    public float lookTimer = 0.0f;
    private float idleTimer = 0.0f;

    public Transform target;

    private PlayerMovement _player;
    private PlayerStats _playerStats;

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
        _playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
       // Raycast işlemi
       Ray ray = new Ray(transform.position, transform.forward);
       RaycastHit hit;
     
       if (Physics.Raycast(ray, out hit))
       {
           Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
           
           // Eğer raycast lambayı vurduysa ve karakter şu anda serbestçe dönmüyorsa
           if ((hit.collider.CompareTag("Lamba") && !isLooking) || hit.collider.CompareTag("Duvar") && !isLooking)
           {
               // Belirli bir noktaya bakma işlemini başlat
               StartLooking();
               Debug.Log("Girdiniz");
               StartCoroutine(StartTiming());
               
           }
     
           if (hit.collider.CompareTag("Fare"))
           {
               _playerStats.ImproveKorku(1);
           }
       }
       else
       {
           Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
       }
    }

    IEnumerator StartTiming()
    {
        transform.LookAt(target);
        yield return new WaitForSeconds(5f);
        _player.speed = 5f;
        isLooking = false;
    }

    // Belirli bir noktaya bakma işlemini başlat
    void StartLooking()
    {
        _player.speed = 0f;
        isLooking = true;
    }
}
