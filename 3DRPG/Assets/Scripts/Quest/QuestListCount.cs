using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestListCount : MonoBehaviour
{
    int currentCount;
    int maxCount;

    Text questTitle;
    Text questCount;

    private void Start()
    {
        questTitle = transform.GetChild(0).GetComponent<Text>();
        questCount = transform.GetChild(1).GetComponent<Text>();

        currentCount = 0;
    }
    public void SetCount(int max)
    {
        maxCount = max;

        questCount.text = currentCount.ToString() + " / " + maxCount.ToString();
    }
    public void SetText(string title)
    {
        questTitle.text = title;
    }
    public string GetTitle()
    {
        return questTitle.text;
    }
    public void AddCount()
    {
        if(maxCount != currentCount)
        {
            currentCount++;
            questCount.text = currentCount.ToString() + " / " + maxCount.ToString();
        }
    }
    public void ResetData()
    {
        currentCount = 0;
        maxCount = 0;
        questTitle.text = "";
        questCount.text = "";
    }
}
