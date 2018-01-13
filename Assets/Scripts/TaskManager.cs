using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<Task> TaskList { get; private set; }

    public TaskUIController taskUIController;

    private void Start()
    {
        TaskList = new List<Task>();
    }

    public void AddTask(Task newTask, bool showUI = false)
    {
        if (!TaskList.Contains(newTask))
        {
            TaskList.Add(newTask);

            if (showUI)
            {
                taskUIController.SetTargetTask(newTask);
            }
        }
    }

    private void Update()
    {
        foreach (var task in TaskList)
        {
            task.Tick();
        }
        TaskList.RemoveAll(t => t.Completed);
    }
}
