using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAround : MonoBehaviour
{
    public bool isOn = false;

    public StraightSwordControllerDemoScript player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isOn = true;
            player = other.GetComponent<StraightSwordControllerDemoScript>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isOn = false;
        }
    }
}
