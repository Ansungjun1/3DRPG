using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public int currnet_Hp = 3;
    private int max_Hp => currnet_Hp;

    public RectTransform hp_Img;
    public Animator hip_Ani;
    public Animator dead_Ani;
    private float hpMaxScale => hp_Img.localScale.x;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EnemySword")
        {
            GetComponent<Animator>().CrossFade("TH_Hit_Forward_01", 0.0f);
            hip_Ani.SetTrigger("hit");
            collision.collider.GetComponent<Sword>().SwordCollider(false);
            GetComponent<StraightSwordControllerDemoScript>().myWeapon.GetComponent<Sword>().SwordCollider(false);
            if (currnet_Hp > 1)
            {
                hp_Img.localScale = new Vector3(hp_Img.localScale.x - hpMaxScale / max_Hp, hp_Img.localScale.y, hp_Img.localScale.z);
                currnet_Hp--;
            }
            else if(currnet_Hp == 1)
            {
                hp_Img.localScale = new Vector3(hp_Img.localScale.x - hpMaxScale / max_Hp, hp_Img.localScale.y, hp_Img.localScale.z);
                currnet_Hp--;
                dead_Ani.SetTrigger("dead");
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject, 0.1f);
            }
        }
    }
}
