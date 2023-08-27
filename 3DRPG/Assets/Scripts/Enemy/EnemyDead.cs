using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : Subject
{
    private int currnet_Hp = 3;
    public bool isOn = false;
    private int max_Hp => currnet_Hp;

    public RectTransform hp_Img;
    public QuestEvent myType;

    bool isAttack = false;

    private float hpMaxScale => hp_Img.localScale.x;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "PlayerSword")
        {
            if(isAttack)
            {
                GetComponent<Animator>().CrossFade("TH_Hit_Forward_01", 0.0f);
                isAttack = !isAttack;
            }
            else
            {
                GetComponent<Animator>().CrossFade("TH_Hit_Forward_02", 0.0f);
                isAttack = !isAttack;
            }
            
            collision.collider.GetComponent<Sword>().SwordCollider(false);
            GetComponent<EnemyStateMachine>().myWeapon.GetComponent<Sword>().SwordCollider(false);
            if (currnet_Hp > 1)
            {
                hp_Img.localScale = new Vector3(hp_Img.localScale.x - hpMaxScale / max_Hp, hp_Img.localScale.y, hp_Img.localScale.z);
                currnet_Hp--;
            }
            else if(currnet_Hp == 1)
            {
                currnet_Hp--;
                notify(QuestEvent.Dead_Monster);
                notify(myType);
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isOn = false;
        }
    }
}
