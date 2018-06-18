using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrk : Ork {

    public float runSpeed = 3;

    // Use this for initialization
    new void Start () {
        base.Start(); 
    }
	
	// Update is called once per frame
	new void FixedUpdate() {
        base.FixedUpdate(); 
    }

    protected override void checkAttack()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(HeroRabbit.lastRabit.GetComponent<BoxCollider2D>()))
        {
            if (!animator.GetBool("isAttack")) animator.SetTrigger("isAttack");
            if (HeroRabbit.lastRabit.transform.position.y > transform.position.y)
            {
                animator.SetBool("isDie", true);
                return;
            }
            else HeroRabbit.lastRabit.GetComponent<Animator>().SetBool("isDie", true);
        }

    }

    protected override float attackDirection()
    {
        Vector3 position = this.transform.position;
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
        //Move towards rabit
        if (speed != runSpeed) speed = runSpeed;

        if (GetComponent<BoxCollider2D>().IsTouching(HeroRabbit.lastRabit.GetComponent<BoxCollider2D>()))
        {
             return 0;
        }
            if (position.x < rabit_pos.x)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }


    protected override bool isDieAnimation()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("greenDie");
    }

}