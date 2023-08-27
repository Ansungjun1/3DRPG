using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestEvent { None, Dead_Monster, CapSkeleton, BaldSkeleton }

public abstract class Observer : MonoBehaviour
{
    public abstract void onNotify(QuestEvent questEvent);
}
