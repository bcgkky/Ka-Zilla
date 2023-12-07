using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    public string konum;

    private TaskManager taskManager;

    void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
        if (taskManager == null)
        {
            Debug.LogError("TaskManager bulunamadı!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Eğer Player bu bölgeye girdiyse, konumu TaskManager'a bildir.
            taskManager.ReportTaskCompletion(konum);
        }
    }
}
