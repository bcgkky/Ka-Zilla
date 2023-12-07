using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class IconControl : MonoBehaviour
{
    public GridLayoutGroup canLayoutGroup;
    public GridLayoutGroup öfkeLayoutGroup;
    public GridLayoutGroup korkuLayoutGroup;
    
    
    public GameObject _can;
    public GameObject _öfke;
    public GameObject _korku;

    public Slider karakterCan;
    public Slider öfke;
    public Slider korku;
    
    void Start()
    {
      ControlCan();
    }
    
    void ControlCan()
    {
        // Mevcut can değerini al
        int currentHealth = Mathf.RoundToInt(karakterCan.value);

        // Eğer zaten instantiate edilmiş ikonlar varsa, onları temizle
        foreach (Transform child in canLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }

        // Can değerine göre ikonları instantiate et
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(_can, canLayoutGroup.transform);
        }
    }

    void ControlKorku()
    {
        // Mevcut can değerini al
        int currentHealth = Mathf.RoundToInt(korku.value);

        // Eğer zaten instantiate edilmiş ikonlar varsa, onları temizle
        foreach (Transform child in korkuLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }

        // Can değerine göre ikonları instantiate et
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(_korku, korkuLayoutGroup.transform);
        }
    }

    void ControlOfke()
    {
        // Mevcut can değerini al
        int currentHealth = Mathf.RoundToInt(öfke.value);

        // Eğer zaten instantiate edilmiş ikonlar varsa, onları temizle
        foreach (Transform child in öfkeLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }

        // Can değerine göre ikonları instantiate et
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(_öfke, öfkeLayoutGroup.transform);
        }
    }
    
    public void OnHealthSliderValueChanged()
    {
        // Slider'ın değeri değiştiğinde çağrılacak olan fonksiyon
        ControlCan();
    }

    public void OnKorkuSliderValueChanged()
    {
        ControlKorku();
    }
    
    public void OnOfkeSliderValueChanged()
    {
        ControlOfke();
    }
}
