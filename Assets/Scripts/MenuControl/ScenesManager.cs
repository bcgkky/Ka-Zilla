using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] gameMenuButtons;
    public GameObject settingsUI;
    public GameObject credits;
    public Button _resume;

    private bool isSettingsOpened;
    private bool isCreditOpened;
    public  Slider karakterCan;

    private void Start()
    {
        settingsUI.SetActive(false);
        credits.SetActive(false);
    }

    private void Update()
    {
        if (karakterCan.value == 0)
        {
            _resume.interactable = false;
            Time.timeScale = 0f;
        }
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Leonardo");
    }

    public void SettingsGame()
    {
        if (!isSettingsOpened)
        {
            settingsUI.SetActive(true);

            foreach (Button buttons in gameMenuButtons)
            {
                buttons.interactable = false;
                isSettingsOpened = true;
            }
        }
        else
        {
            settingsUI.SetActive(false);
            foreach (Button buttons in gameMenuButtons)
            {
                buttons.interactable = true;
                isSettingsOpened = false;
            }
        }
      
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void CredistControl()
    {
        if (!isCreditOpened)
        {
            credits.SetActive(true);
            isCreditOpened = true;
        }
        else
        {
            credits.SetActive(false);
            isCreditOpened = false;
        }
        
    }
}
