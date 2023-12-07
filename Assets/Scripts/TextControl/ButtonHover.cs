using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI buttonText;
    private Color normalColor;
    public Color hoverColor = Color.green;

    private void Start()
    {
        // Script başladığında butonun normal rengini al.
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        normalColor = buttonText.color;
    }

    // Mouse buton üzerine geldiğinde çalışacak fonksiyon.
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor; // Rengi değiştir.
    }

    // Mouse butondan çıkıldığında çalışacak fonksiyon.
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor; // Orijinal rengine döndür.
    }
}
