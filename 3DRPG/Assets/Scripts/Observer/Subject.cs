using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    List<Observer> observers = new List<Observer>();
    Observer questManager = new QuestManager();
    private void Start()
    {
        observers.Add(questManager);
    }

    protected void notify(QuestEvent questEvent)
    {
        for(int i = 0; i < observers.Count; i++)
        {
            observers[i].onNotify(questEvent);
        }
    }
}
