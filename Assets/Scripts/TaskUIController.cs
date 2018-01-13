using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUIController : MonoBehaviour
{
    public Text timeTextUI;
    void Start()
    {
        this.enabled = false;
        timeTextUI.enabled = false;
    }

    public void SetTargetTask(Task task)
    {
        task.OnTaskTimerAdvanced += UpdateUI;
        task.OnTaskCompleted += (Task t) => { timeTextUI.enabled = false; };
        timeTextUI.enabled = true;
    }

    public void UpdateUI(Task task)
    {
        System.TimeSpan t = System.TimeSpan.FromSeconds(task.TimeRemainning);

        string time = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                        t.Hours,
                        t.Minutes,
                        t.Seconds);
        timeTextUI.text = time;

    }
}
