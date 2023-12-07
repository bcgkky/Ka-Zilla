using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturationControl : MonoBehaviour
{
    private bool isBlackAndWhite = false;
    private Material originalMaterial;

    void Awake()
    {
        // Orijinal malzemeyi kaydet
        originalMaterial = new Material(Shader.Find("Standard"));
    }

    void Update()
    {
        // "B" tuşuna basıldığında efekti toggle et
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBlackAndWhite = !isBlackAndWhite;
            ApplyBlackAndWhiteEffect();
            StartCoroutine(ResetSaturation());
        }
    }

    void ApplyBlackAndWhiteEffect()
    {
        if (isBlackAndWhite)
        {
            // Tüm objelerin üzerinde dolaş ve siyah-beyaz efektini uygula
            foreach (Renderer renderer in FindObjectsOfType<Renderer>())
            {
                // Player tag'ine sahip objeleri es geç
                if (renderer.CompareTag("Player"))
                    continue;

                Material material = new Material(Shader.Find("Standard"));
                material.SetFloat("_Saturation", 0);

                // Objeye siyah-beyaz malzemeyi uygula
                renderer.material = material;
            }
        }
    }

    IEnumerator ResetSaturation()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Girildi");
        foreach (Renderer renderer in FindObjectsOfType<Renderer>())
        {
            // Player tag'ine sahip objeleri es geç
            if (renderer.CompareTag("Player"))
                continue;

            // Objeye orijinal malzemeyi uygula
            renderer.material = originalMaterial;
        }
    }
}
