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
                    Debug.Log("����");
                    //����Ʈ 1 ����.
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
