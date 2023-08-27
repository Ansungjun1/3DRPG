using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectManager : MonoBehaviour
{
    public Observer[] observers;
    void Awake()
    {
        observers = FindObjectsOfType<Observer>();
    }

    public Observer[] GetObservers()
    {
        return observers;
    }
}
