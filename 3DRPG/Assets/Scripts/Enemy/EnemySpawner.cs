using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Observer
{
    public GameObject prefab_Monster;

    private QuestEvent questEvent;

    private void Start()
    {
        questEvent = prefab_Monster.GetComponent<EnemyDead>().myType;
    }

    public override void onNotify(QuestEvent questEvent)
    {
        if(questEvent == this.questEvent)
            Spawn();
    }


    void Spawn()
    {
        Instantiate(prefab_Monster, prefab_Monster.transform.position, Quaternion.identity, this.transform);
    }
}
