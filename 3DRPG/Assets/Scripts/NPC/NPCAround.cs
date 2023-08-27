using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAround : MonoBehaviour
{
    QuestNPC myNPC;

    private void Start()
    {
        myNPC = transform.parent.GetComponent<QuestNPC>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<StraightSwordControllerDemoScript>().OnNPC(myNPC);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<StraightSwordControllerDemoScript>().OffNPC();
        }
    }
}
