using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Task : ScriptableObject
{
    public float TimeRemainning { get; private set; }
    public bool Completed { get; private set; }

    public float timeRequired;

    public delegate void TaskStateChangedDelegate(Task task);
    public event TaskStateChangedDelegate OnTaskCompleted = delegate { };
    public event TaskStateChangedDelegate OnTaskTimerAdvanced = delegate { };

    public virtual void Init(float timeRequired)
    {
        Completed = false;
        this.timeRequired = timeRequired;
        TimeRemainning = timeRequired;
    }

    public virtual void Tick()
    {
        if (TimeRemainning <= 0)
        {
            OnTaskCompleted(this);
            Completed = true;
            return;
        }

        TimeRemainning -= Time.deltaTime;
        OnTaskTimerAdvanced(this);
    }
}
