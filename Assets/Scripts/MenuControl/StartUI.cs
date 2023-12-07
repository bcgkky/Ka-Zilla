using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    
    public GameObject startUI;

    public  bool isPressed;
    private void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           CloseUI();
        }
    }

    public void CloseUI()
    {
        Time.timeScale = 1f;
        startUI.SetActive(false);
        isPressed = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<forDarbe>().enabled = true;
    }
}
