using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestEvent { None, Dead_Monster }
public class QuestManager : Observer
{
    public override void onNotify(QuestEvent questEvent)
    {
        switch(questEvent)
        {
            case QuestEvent.Dead_Monster:
                {
                    Debug.Log("실행");
                    //퀘스트 1 증가.
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
