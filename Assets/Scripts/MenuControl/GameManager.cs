using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused = false;

// Ekran üzerinde gösterilecek Pause menüsü
    public GameObject pauseMenu;
    public GameObject player;
    public Slider karakterCan;
    public Button resumeButton;

    void Start()
    {
        // Resume butonuna tıklanınca ResumeGame fonksiyonunu çağır
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // "ESC" tuşuna basıldığında oyunu duraklat veya devam ettir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            resumeButton.onClick.AddListener(ResumeGame);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().karakterCan == 0)
        {
            pauseMenu.SetActive(true);
        }
    }

// Oyunu duraklat
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f; // Zamanı durdur (hareket etmeyi duraklat)
        pauseMenu.SetActive(true); // Pause menüsünü göster
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

// Oyunu devam ettir
    public void ResumeGame()
    {
            Debug.Log("deneme");
            isGamePaused = false;
            Time.timeScale = 1f; // Zamanı tekrar başlat (hareketi devam ettir)
            pauseMenu.SetActive(false); // Pause menüsünü gizle
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; // Mouse'u gizle
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
