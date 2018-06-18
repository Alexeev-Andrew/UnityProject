using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeOrc : Ork {

    public GameObject prefabCarrot;
    public int timeOfThrowing;
    float timeCur;


    // Use this for initialization
    new void Start () {
        base.Start();
        timeCur = timeOfThrowing;

    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void checkAttack()
    {
        Vector3 position = this.transform.position;
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
        if (GetComponent<BoxCollider2D>().IsTouching(HeroRabbit.lastRabit.GetComponent<BoxCollider2D>()))
        {
            if (HeroRabbit.lastRabit.transform.position.y > transform.position.y)
            {
                animator.SetBool("isDie", true);
                return;
            }
        }
        if (mode==Mode.Attack)//rabit_pos.x > pointA.x && rabit_pos.x < pointB.x
        {

           
            if (rabit_pos.x > position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                if (timeCur > 0)
                {
                    timeCur -= Time.deltaTime;
                    return;
                }
                animator.SetTrigger("isAttack");
                this.launchCarrot(1);
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                if (timeCur > 0)
                {
                    timeCur -= Time.deltaTime;
                    return;
                }
                animator.SetTrigger("isAttack");
                this.launchCarrot(-1);
            }
            timeCur = timeOfThrowing;
        }
    }

    protected override float attackDirection()
    {
        return 0;
    }

    void launchCarrot(float direction)
    {
        //Створюємо копію Prefab
        GameObject obj = GameObject.Instantiate(this.prefabCarrot);
        //Розміщуємо в просторі
        obj.transform.position = this.transform.position + new Vector3(0, this.GetComponent<BoxCollider2D>().size.y/2-0.2f, 0);
       //Запускаємо в рух
       Carrot carrot = obj.GetComponent<Carrot>();
        
        carrot.launch(direction);
    }

    protected override bool isDieAnimation()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("orangeDie");
    }


}
