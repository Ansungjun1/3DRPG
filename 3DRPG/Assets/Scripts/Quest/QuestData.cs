using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class QuestData : ScriptableObject
{
    public string questName => questName_;
    [SerializeField] string questName_;

    public string[] AcceptContents => AcceptContents_;
    [SerializeField] string[] AcceptContents_;

    public string[] RequestContents => RequestContents_;
    [SerializeField] string[] RequestContents_;

    public string[] completeContents => completeContents_;
    [SerializeField] string[] completeContents_;

    public QuestComplete[] questComplete => questComplete_;
    [SerializeField] QuestComplete[] questComplete_;

    public void CheckCompleteQuest(QuestEvent questEvent)
    {
        bool isCheck = false;
        for(int i = 0; i < questComplete.Length; i++)
        {
            isCheck = questComplete[i].CompleteCount(questEvent);

            if (isCheck == false)
                return;
        }

        //Äù½ºÆ® ¿Ï·á
    }
    public bool CheckCompleteQuest()
    {
        bool isCheck = false;
        for (int i = 0; i < questComplete.Length; i++)
        {
            isCheck = questComplete[i].CompleteCount();

            if (isCheck == false)
                return false;
        }

        return true;
        //Äù½ºÆ® ¿Ï·á
    }

    public void SetQuest()
    {
        for (int i = 0; i < questComplete.Length; i++)
        {
            questComplete[i].SetQuest();
        }
    }
}
