using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/QuestComplete")]
public class QuestComplete : ScriptableObject
{
    int currentCount = 0;
    public int maxCount => maxCount_;
    [SerializeField] int maxCount_;

    public QuestEvent questEvent => questEvent_;
    [SerializeField] QuestEvent questEvent_;

    
    public bool CompleteCount(QuestEvent quest)
    {
        if(quest != questEvent)
            return currentCount == maxCount; ;
        
        UpCount();
        return currentCount == maxCount;
    }
    public bool CompleteCount()
    {
        return currentCount == maxCount;
    }

    void UpCount()
    {
        if (currentCount < maxCount)
            currentCount++;
        Debug.Log(currentCount);
    }

    public void SetQuest()
    {
        currentCount = 0;
    }
}
