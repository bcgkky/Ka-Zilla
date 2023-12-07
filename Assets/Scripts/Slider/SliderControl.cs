using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{ 
    public Slider KarakterCan;
    public Slider mutluluk;
    public Slider korku;
    public Slider öfke;
    public Slider güç;


    public void SetMaxHealth(float health)
    {
        KarakterCan.maxValue = health;
        KarakterCan.value = health;
    }

    public void SetHealth(float health)
    {
        KarakterCan.value = health;
    }
    
    public void SetMaxKorku(float korku)
    {
        this.korku.maxValue = korku;
        this.korku.value = korku;
    }

    public void SetKorku(float korku)
    {
        this.korku.value = korku;
    }
    
    public void SetMaxOfke(float ofke)
    {
        öfke.maxValue = ofke;
        öfke.value = ofke;
    }

    public void SetOfke(float ofke)
    {
        öfke.value = ofke;
    }

    public void SetMaxGuc(float guc)
    {
        güç.maxValue = guc;
        güç.value = guc;
    }

    public void SetGuc(float guc)
    {
        güç.value = guc;
    }
}
