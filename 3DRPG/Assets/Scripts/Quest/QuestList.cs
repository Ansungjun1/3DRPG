using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : Observer
{
    private GameObject[] questList;
    private QuestEvent[] questEventName;

    // Start is called before the first frame update
    void Start()
    {
        questList = new GameObject[transform.childCount];
        questEventName = new QuestEvent[transform.childCount];

        for(int i = 0; i < questList.Length; i++)
        {
            questList[i] = transform.GetChild(i).gameObject;
            questEventName[i] = QuestEvent.None;
        }
    }

    public void SetQuest(string title, int maxCount, QuestEvent questEvent)
    {
        for(int i = 0; i < questEventName.Length; i++)
        {
            if(questEventName[i] == QuestEvent.None)
            {
                questList[i].GetComponent<QuestListCount>().SetText(title);
                questList[i].GetComponent<QuestListCount>().SetCount(maxCount);

                questEventName[i] = questEvent;
                break;
            }
        }
    }

    public void ResetQuest(string title)
    {
        for (int i = 0; i < questEventName.Length; i++)
        {
            if (questEventName[i] != QuestEvent.None && questList[i].GetComponent<QuestListCount>().GetTitle() == title)
            {
                questList[i].GetComponent<QuestListCount>().ResetData();

                questEventName[i] = QuestEvent.None;
                break;
            }
        }
    }

    public override void onNotify(QuestEvent questEvent)
    {
        for(int i = 0; i < questEventName.Length; i++)
        {
            if(questEvent == questEventName[i])
            {
                questList[i].GetComponent<QuestListCount>().AddCount();
            }
        }
    }
}
