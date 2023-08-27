using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPCState
{
    protected int count;
    protected int Maxcount;
    
    public abstract NPCState NextContexts(QuestNPC questNPC, NPCState npcState, List<QuestData> questData, int num, ContextsCanvas contexts);
    public abstract void EnterContexts(QuestNPC questNPC, List<QuestData> questData, int num, ContextsCanvas contexts);
}

public class NPCNullState : NPCState
{
    public override NPCState NextContexts(QuestNPC questNPC, NPCState npcState, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        if(count == Maxcount)
        {
            count = 0;
            contexts.GetComponent<Canvas>().enabled = false;

            return npcState;
        }
        else
        {
            contexts.myText.text = questNPC.npcNullContexts[count];
            count++;
            return npcState;
        }
    }

    public override void EnterContexts(QuestNPC questNPC, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        count = 0;
        contexts.GetComponent<Canvas>().enabled = true;

        Maxcount = questNPC.npcNullContexts.Length;
        contexts.myText.text = questNPC.npcNullContexts[count];
        count++;
    }
}
public class NPCAcceptState : NPCState
{
    public override NPCState NextContexts(QuestNPC questNPC, NPCState npcState, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        Debug.Log("Accept");
        if (count == Maxcount)
        {
            count = 0;
            Debug.Log("체인지");
            contexts.GetComponent<Canvas>().enabled = false;

            Transform.FindObjectOfType<QuestManager>().AddQuest(questData[num]);
            Transform.FindObjectOfType<QuestList>().SetQuest(questData[num].questName, questData[num].questComplete[0].maxCount, questData[num].questComplete[0].questEvent);
            //퀘스트 수락.

            
            return new NPCRequestState();
        }
        else
        {
            contexts.myText.text = questData[num].AcceptContents[count];
            count++;
            return npcState;
        }

    }

    public override void EnterContexts(QuestNPC questNPC, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        count = 0;
        contexts.GetComponent<Canvas>().enabled = true;

        Maxcount = questData[num].AcceptContents.Length;

        if (Maxcount != 0)
            contexts.myText.text = questData[num].AcceptContents[count];
        count++;
    }
}
public class NPCRequestState : NPCState
{
    public override NPCState NextContexts(QuestNPC questNPC, NPCState npcState, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        Debug.Log("Request");
        if (questData[num].CheckCompleteQuest())
        {
            contexts.myText.text = questData[num].RequestContents[count];
            count = 0;
            Debug.Log("성공");
            
            contexts.CompleteText();

            return new NPCCompleteState();
        }

        Debug.Log("실패");

        if (count == Maxcount)
        {
            count = 0;

            contexts.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            contexts.myText.text = questData[num].RequestContents[count];
        }
        contexts.NextText();
        count++;

        
        return npcState;
    }

    public override void EnterContexts(QuestNPC questNPC, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        count = 0;
        contexts.GetComponent<Canvas>().enabled = true;

        Maxcount = questData[num].RequestContents.Length;

        if (Maxcount != 0)
            contexts.myText.text = questData[num].RequestContents[count];
        count++;

        
    }
}
public class NPCCompleteState : NPCState
{

    public override NPCState NextContexts(QuestNPC questNPC, NPCState npcState, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        if(count == 0)
        {
            Maxcount = questData[num].completeContents.Length;
            contexts.NextText();
            if (Maxcount != 0)
                contexts.myText.text = questData[num].completeContents[count];
            count++;
            return npcState;
        }

        if (count == Maxcount)
        {
            contexts.GetComponent<Canvas>().enabled = false;

            //퀘스트 완료.
            Transform.FindObjectOfType<QuestList>().ResetQuest(questData[num].questName);
            Transform.FindObjectOfType<QuestManager>().RemoveQuest(questData[num]);
            
            questNPC.questList.Remove(questData[num]);

            if (questNPC.questList.Count != 0)
            {
                return new NPCAcceptState();
            }
            else
            {
                return new NPCNullState();
            }
        }
        else
            contexts.myText.text = questData[num].completeContents[count];
        count++;
        return npcState;
    }
    public override void EnterContexts(QuestNPC questNPC, List<QuestData> questData, int num, ContextsCanvas contexts)
    {
        count = 0;
        contexts.GetComponent<Canvas>().enabled = true;

        
    }
}