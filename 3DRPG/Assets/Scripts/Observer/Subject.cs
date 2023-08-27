using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public Observer[] observers;

    protected void Start()
    {
        observers = FindObjectOfType<SubjectManager>().GetObservers();
    }

    protected void notify(QuestEvent questEvent)
    {
        for(int i = 0; i < observers.Length; i++)
        {
            observers[i].onNotify(questEvent);
        }
    }
}
