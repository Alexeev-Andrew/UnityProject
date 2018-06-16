using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {

    public Vector3 MoveBy;
    Vector3 pointA;
    Vector3 pointB;
    public float speed = 2;
    public float time_to_wait = 3;
    public float timeOfWaiting;
    Vector3 moveVector;
    Vector3 pauseVector;
    bool moveToA;

    // Use this for initialization
    void Start () {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;
        float t1 = (pointB - pointA).x;
        float t2 = (pointB.y - pointA.y);
        float t3 = Mathf.Sqrt(t1*t1+t2*t2);
        t3 /= speed;

        moveVector = new Vector3(t1/t3, t2/t3,0);
        pauseVector = new Vector2(); 
        moveToA = false;
        timeOfWaiting = time_to_wait;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeOfWaiting > 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            timeOfWaiting -= Time.deltaTime;
            rb.velocity = pauseVector;
        }
        else
        {
            Vector3 my_pos = this.transform.position;
            if (moveToA)
            {
                if (isArrived(my_pos, pointA))
                {
                    moveToA = !moveToA;
                    timeOfWaiting = time_to_wait;
                    moveVector.x *= -1;
                    moveVector.y *= -1;
                }
            }
            else
                if (isArrived(my_pos, pointB))
            {
                moveToA = !moveToA;
                timeOfWaiting = time_to_wait;
                moveVector.x = -moveVector.x;
                moveVector.y = -moveVector.y;
            }
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = moveVector;
        }
    }

    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.02f;
    }

}
