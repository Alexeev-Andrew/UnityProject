using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ork : MonoBehaviour
{

    protected Vector3 pointA;
    protected Vector3 pointB;
    public Vector3 MoveBy;
    protected float speed;
    public float walkSpeed = 2;
    public float time_to_wait = 3;
    public Mode mode;

    float curWaiting = 0;


    protected Rigidbody2D myBody = null;
    protected Animator animator;

    // Use this for initialization
    protected void Start()
    {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;
        if (pointA.x > pointB.x)
        {
            Vector3 v = pointA;
            pointA = pointB;
            pointB = v;
        }
        mode = Mode.GoToB;
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        curWaiting = time_to_wait;
        speed = walkSpeed;
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (animator.GetBool("isDie"))
        {
            //якщо анімація ще не змінилась або якщо анімація смерті завершила свою роботу
            if (!isDieAnimation()|| animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
                    return;
            animator.SetBool("isDie", false);

            Destroy(this.gameObject);
            return;
        }

        checkAttack();
        float value = this.getDirection();

        if (mode == Mode.Stay)
        {
            if (curWaiting > 0)
            {
                curWaiting -= Time.deltaTime;
                return;
            }
            else
            {
                if (distX(transform.position,pointA)<distX(transform.position,pointB)) mode = Mode.GoToB;
                else mode = Mode.GoToA;
                animator.SetBool("isIdle", false);
            }
        }

        if (Mathf.Abs(value) > 0)
        {
            animator.SetBool("isRun", mode == Mode.Attack);
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;

        }
        animator.SetBool("isRun", mode == Mode.Attack);
        /* else
             if (mode == Mode.Attack) animator.SetTrigger("isAttack");
             */

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = false;
        }
        else if (value > 0)
        {
            sr.flipX = true;
        }


    }


    public enum Mode
    {
        GoToA,
        GoToB,
        Attack,
        Stay
    }

    float getDirection()
    {
        Vector3 position = this.transform.position;
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;

        if (rabit_pos.x > pointA.x && rabit_pos.x < pointB.x)
        {
            mode = Mode.Attack;
        }
        else if (mode == Mode.Attack)
        {
            mode = Mode.GoToA;
            speed = walkSpeed;
        }

        if (mode == Mode.Attack)
        {
            return attackDirection();
        }

        if (mode == Mode.GoToB)
        {
            if (isArrivedX(position, pointB))
            {
                mode = Mode.Stay;
                curWaiting = time_to_wait;
                animator.SetBool("isIdle", true);
            }
            else return 1;
        }
        else if (mode == Mode.GoToA)
        {
            if (isArrivedX(position, pointA))
            {
                mode = Mode.Stay;
                curWaiting = time_to_wait;
                animator.SetBool("isIdle", true);
            }
            else return -1;
        }
    
        return 0;
    }

    bool isArrivedX(Vector3 pos, Vector3 target)
    {
        return distX(pos, target) < 0.1f;
    }

    float distX(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        pos.y = 0;
        target.y = 0;
        return Vector3.Distance(pos, target);
    }

    public void hide()
    {
        Destroy(this.gameObject);
    }

    protected abstract float attackDirection();
    protected abstract void checkAttack();
    protected abstract bool isDieAnimation();
}
