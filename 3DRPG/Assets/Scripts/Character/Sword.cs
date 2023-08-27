using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public void SwordCollider(bool isOn)
    {
        GetComponent<CapsuleCollider>().enabled = isOn;
    }
}
