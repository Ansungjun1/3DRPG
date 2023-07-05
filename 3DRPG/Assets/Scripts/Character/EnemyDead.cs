using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : Subject
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerSword")
        {
            notify(QuestEvent.Dead_Monster);
        }
    }
}
