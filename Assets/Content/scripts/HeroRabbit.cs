using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit : MonoBehaviour {

    public static HeroRabbit lastRabit = null;

    Rigidbody2D myBody = null;
    public float speed = 1;
    Vector3 startPosition;//= new Vector3(0, 0);
    bool JumpActive = false;
    float JumpTime = 0f;
    Animator animator;

    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;
    bool isBig = false;


    void Awake()
    {
        lastRabit = this;
    }

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        setStartPosition(myBody.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (animator.GetBool("isDie"))
        {
            //якщо анімація ще не змінилась або якщо анімація смерті завершила свою роботу
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("rabbit_die_animation") || animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime) return;
            animator.SetBool("isDie", false);
            LevelController.current.onRabitDeath(this);
            return;
        }

        //[-1, 1]
        float value = Input.GetAxis("Horizontal");
        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {
            //Якщо кнопку ще тримають
            if (Input.GetButton("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;
            }
        }


        
        if (Mathf.Abs(value) > 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        if (this.isGrounded())
        {
            animator.SetBool("isJump", false);
        }
        else
        {
            animator.SetBool("isJump", true);
        }
    }



    bool isGrounded()
    {
        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit) return true;
        return false;
    }

    public void onRabbitDeath()
    {
        if (isBig)
        {
            isBig = false;
            Vector3 currSize = this.transform.localScale;
            this.transform.localScale = new Vector3(currSize.x / 1.5f, currSize.y / 1.5f, 0);
        }
        myBody.MoveRotation(0);
        myBody.angularVelocity = 0;
        this.transform.position = this.startPosition;
    }

    public void setStartPosition(Vector3 position)
    {
        this.startPosition = position;
    }

    public void setBig(bool flag)
    {
        isBig = flag;
    }
    public bool isBigg()
    {
        return isBig;
    }
}
