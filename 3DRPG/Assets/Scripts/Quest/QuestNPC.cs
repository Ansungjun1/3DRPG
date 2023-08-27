using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestNPC : MonoBehaviour
{
    public List<QuestData> questList = new List<QuestData>();
    int currentQuest = 0;

    
    public NPCState npcState;

    public ContextsCanvas Contexts;
    [SerializeField]
    private GameObject quest_Icon;

    public string[] npcNullContexts;
    private void Start()
    {
        Contexts = FindObjectOfType<ContextsCanvas>();

        if(questList.Count != 0)
        {
            npcState = new NPCAcceptState();
        }
        else
        {
            npcState = new NPCNullState();
            quest_Icon.SetActive(false);
        }
    }

    public void ContextsNPC()
    {
        npcState.EnterContexts(this, questList, currentQuest, Contexts);
    }

    public void ContextsNextNPC()
    {
        npcState = npcState.NextContexts(this, npcState, questList, currentQuest, Contexts);

        if (questList.Count == 0)
            quest_Icon.SetActive(false);
    }
}
