using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
    public float karakterCan = 9;
    public float korku;
    public float öfke;
    public float mutluluk;
    public float güç;

    public SliderControl _sliderControl;
    

    private void Start()
    {
        
        _sliderControl.SetMaxHealth(karakterCan);
        _sliderControl.SetMaxKorku(10);
        _sliderControl.SetMaxOfke(10);
        _sliderControl.SetMaxGuc(10);
        _sliderControl.SetKorku(0);
        _sliderControl.SetOfke(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (korku > 10 )
        {
            StartCoroutine(ResetStats());
        }
       // if (Input.GetKeyDown(KeyCode.J))
       // {
       //     ImproveKorku(1);
       //     ControlKorku(); 
       // }
       // if (Input.GetKeyDown(KeyCode.L))
       // {
       //     ImproveOfke(1);
       // }
        ControlOfke();
        //V tuşuna basılma durumu.
    
    }

    public void ImproveOfke(int i)
    {
        öfke += i;
        _sliderControl.SetOfke(öfke);
    }

    public void DecreaseOfke(int i)
    {
        öfke -= i;
        _sliderControl.SetOfke(öfke);
    }


    private void ControlOfke() // Öfkeyi kontrol ettiğimiz kısım
    {
        if (korku > 5 && korku < 10)
        {
            öfke += Time.deltaTime / 2;
            _sliderControl.SetOfke(öfke);
            if (öfke >= 10)
            {
                öfke = 10;
                _sliderControl.SetOfke(öfke);
            }
        }
        
        else if (korku >= 10)
        {
            öfke = 10;
            _sliderControl.SetOfke(öfke);
        }
        
        if (öfke < 0)
        {
            öfke = 0;
            _sliderControl.SetOfke(öfke);
        }
        
    }

    public void ImproveKorku(int i)
    {
        korku += i;
        _sliderControl.SetKorku(korku);
    }
    
    public void DescreaseKorku(int i)
    {
        korku -= i;
        _sliderControl.SetKorku(korku);
    }

    private void ControlKorku() //Korkuyu kontrol ettiğim kısım.
    {
        if (korku >= 10)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_WalkSpeed = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_RunSpeed = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_JumpSpeed = 0;
        }
    }


    public void Damage(float damage)
    {
        karakterCan -= damage;
        _sliderControl.SetHealth(karakterCan);
        //Can kontrol sistemi konmalı. 
    }

    public void AddHealthFood(float HealthlyFood)
    {
        karakterCan += HealthlyFood;
        _sliderControl.SetHealth(karakterCan);
    }


    IEnumerator ResetStats() // Öfke ve korkunun sıfırlandığı bölge
    {
        ControlKorku();
        yield return new WaitForSeconds(5f);
        _sliderControl.SetKorku(0);
        _sliderControl.SetOfke(0);
        korku = 0;
        öfke = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_WalkSpeed = 5;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_RunSpeed = 10;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().m_JumpSpeed = 10;
    }
}
