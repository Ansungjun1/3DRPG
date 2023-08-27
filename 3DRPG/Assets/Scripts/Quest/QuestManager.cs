using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : Observer
{
    public List<QuestData> questList = new List<QuestData>();

    public override void onNotify(QuestEvent questEvent)
    {
        switch(questEvent)
        {
            case QuestEvent.Dead_Monster:
                {
                    Debug.Log("½ÇÇà");
                    FindQuestList(questEvent);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void FindQuestList(QuestEvent questEvent)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            questList[i].CheckCompleteQuest(questEvent);
        }
    }

    public void AddQuest(QuestData questData)
    {
        questData.SetQuest();
        questList.Add(questData);
    }
    public void RemoveQuest(QuestData questData)
    {
        questList.Remove(questData);
    }
    
}
