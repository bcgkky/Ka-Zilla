using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public TMP_Text taskText;
    public Image tickImage;
    public Sprite incompleteSprite;
    public Sprite completeSprite;

    public GameObject[] locationIcons; // Konum ikonları

    private List<string> tasks;
    private int currentTaskIndex = 0;
    private bool isCompleted = false;

    void Start()
    {
        ActivateLocationIcon(currentTaskIndex);
        tasks = new List<string>
        {
            "Görev 1: A noktasında yap",
            "Görev 2: B noktasında yap",
            "Görev 3: C noktasında yap",
            "Görev 4: D noktasında yap",
            "Görev 5: E noktasında yap"
        };
        isCompleted = false;
        ShowTask();
    }

    void ShowTask()
    {
        if (currentTaskIndex >= tasks.Count)
        {
            taskText.text = "Tüm görevler tamamlandı!";
            tickImage.sprite = completeSprite;
            return;
        }

        taskText.text = tasks[currentTaskIndex];
        tickImage.sprite = incompleteSprite;

        // Görev konum ikonunu aktifleştir
        ActivateLocationIcon(currentTaskIndex);
    }

    void ActivateLocationIcon(int index)
    {
        // Index sınırları kontrolü
        if (index >= 0 && index < locationIcons.Length)
        {
            // İlgili konum ikonunu aktifleştir
            locationIcons[index].SetActive(true);
        }
    }

    public bool IsTaskCompleted()
    {
        return isCompleted;
    }

    public void CompleteTask()
    {
        tickImage.sprite = completeSprite;
        StartCoroutine(ResetTickAndShowNextTask());
        isCompleted = true;
        Debug.Log("Tamamlandı");
    }

    IEnumerator ResetTickAndShowNextTask()
    {
        yield return new WaitForSeconds(3f);
        tickImage.sprite = null;
        currentTaskIndex++;
        ShowTask();
    }

    // Bu fonksiyonu her konumda çağırarak görevin tamamlandığını bildirebilirsiniz.
    public void ReportTaskCompletion(string konum)
    {
        if (taskText.text.Contains(konum))
        {
            CompleteTask();
        }
    }
}
